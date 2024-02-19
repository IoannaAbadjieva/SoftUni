namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
        private Dictionary<string, Owner> owners = new Dictionary<string, Owner>();

        public int Size => this.dogs.Count;

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogs.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (owner.Dogs.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            if (!this.owners.ContainsKey(owner.Id))
            {
                this.owners.Add(owner.Id, owner);
            }

            this.dogs.Add(dog.Id, dog);
            dog.Owner = owner;
            owner.Dogs.Add(dog.Name, dog);

        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            var owner = this.owners[ownerId];

            if (!owner.Dogs.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return owner.Dogs[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            var dog = this.GetDog(name, ownerId);
            var owner = this.owners[ownerId];

            this.dogs.Remove(dog.Id);
            owner.Dogs.Remove(dog.Name);

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.owners[ownerId].Dogs.Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var dogsByBreed= this.dogs.Values
                .Where(d => d.Breed == breed);

            if (dogsByBreed.Count() == 0)
            {
                throw new ArgumentException();
            }

            return dogsByBreed;
        }

        public void Vaccinate(string name, string ownerId)
        {
            var dog = this.GetDog(name, ownerId);
            dog.Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            var dog = this.GetDog(oldName, ownerId);
            var owner = this.owners[ownerId];

            dog.Name = newName;
            owner.Dogs.Remove(oldName);
            owner.Dogs.Add(newName, dog);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var dogsByAge = this.dogs.Values
                .Where(d => d.Age == age);

            if (dogsByAge.Count() == 0)
            {
                throw new ArgumentException();
            }

            return dogsByAge;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            return this.dogs.Values
                .Where(d => d.Age >= lo && d.Age <= hi);
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.dogs.Values
                .OrderBy(d => d.Age)
                .ThenBy(d => d.Name)
                .ThenBy(d => d.Owner.Name);
        }
    }
}