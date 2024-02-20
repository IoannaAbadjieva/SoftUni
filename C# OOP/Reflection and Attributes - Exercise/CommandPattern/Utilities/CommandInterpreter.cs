namespace CommandPattern.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Core.Contracts;
    
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string cmdName = args.Split(' ')[0];
            string[] cmdArgs = args.Split().Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command");

            if (cmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = cmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(mi => mi.Name == "Execute");

            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement ICommand interface!");
            }

            object cmdInstance = Activator.CreateInstance(cmdType);
            string result = (string)executeMethodInfo
                .Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
