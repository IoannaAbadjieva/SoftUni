// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor;

using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

using Data;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.DataProcessor.ImportDto;
using TeisterMask.Data.Models;
using System.Globalization;
using TeisterMask.Data.Models.Enums;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedProject
        = "Successfully imported project - {0} with {1} tasks.";

    private const string SuccessfullyImportedEmployee
        = "Successfully imported employee - {0} with {1} tasks.";

    public static string ImportProjects(TeisterMaskContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]),
                                                        new XmlRootAttribute("Projects"));
        StringReader reader = new StringReader(xmlString);
        ImportProjectDto[] projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(reader);

        ICollection<Project> validProjects = new HashSet<Project>();

        foreach (var projectDto in projectDtos)
        {
            if (!IsValid(projectDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);

            if (!isOpenDateValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            DateTime? dueDate = null!;

            if (!string.IsNullOrEmpty(projectDto.DueDate))
            {
                bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateParsed);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                dueDate = dueDateParsed;
            }

            ICollection<Task> validTasks = new HashSet<Task>();

            foreach (var taskDto in projectDto.Tasks)
            {
                if (!IsValid(taskDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                if (!isTaskOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                if (!isTaskDueDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (taskOpenDate < openDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dueDate.HasValue && taskDueDate > dueDate.Value)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Task task = new Task()
                {
                    Name = taskDto.Name,
                    OpenDate = taskOpenDate,
                    DueDate = taskDueDate,
                    ExecutionType = (ExecutionType)taskDto.ExecutionType,
                    LabelType = (LabelType)taskDto.LabelType
                };

                validTasks.Add(task);
            }

            Project project = new Project()
            {
                Name = projectDto.Name,
                OpenDate = openDate,
                DueDate = dueDate,
                Tasks = validTasks
            };

            validProjects.Add(project);
            sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, validTasks.Count));
        }

        context.Projects.AddRange(validProjects);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportEmployees(TeisterMaskContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

        ICollection<Employee> validEmployees = new HashSet<Employee>();

        foreach (var employeeDto in employeeDtos)
        {
            if (!IsValid(employeeDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Employee employee = new Employee()
            {
                Username = employeeDto.Username,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone
            };

            foreach (var taskId in employeeDto.Tasks.Distinct())
            {
                if (context.Tasks.Find(taskId) == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                employee.EmployeesTasks.Add(new EmployeeTask()
                {
                    TaskId = taskId,
                });
            }

            validEmployees.Add(employee);
            sb.AppendLine(string.Format(SuccessfullyImportedEmployee,
                employee.Username, employee.EmployeesTasks.Count)); ;
        }

        context.Employees.AddRange(validEmployees);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}