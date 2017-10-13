using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;

namespace dojodachi
{
    public class Dachi{   
        public int happiness;
        public int fullness;
        public int energy;
        public int meals;

        public Dachi(){
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
    }
}
