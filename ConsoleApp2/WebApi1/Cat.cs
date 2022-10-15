using System;

namespace WebApi1
{
    public class Cat : Animal
    {
        public void Meow() 
        {
            var t = this.name;
        }

        public void Walk(string poit) { }

        public void Walk(string point1, string point2) { }
    }
}
