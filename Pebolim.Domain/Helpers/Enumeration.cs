﻿using System.Reflection;

namespace Pebolim.Domain.Helpers
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object? obj)
        {
            Enumeration? enumeration = obj as Enumeration;
            return Id.CompareTo(enumeration?.Id);
        }

        public static T GetByName<T>(string name) where T : Enumeration
        {
            return GetAll<T>().First(e => e.Name == name);
        }

        public static T GetById<T>(int id) where T : Enumeration
        {
            return GetAll<T>().First(e => e.Id == id);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}