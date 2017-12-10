using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DSED03.Guy;

namespace DSED03
{
    public static class Factory
    {
        private static Random Random = new Random();

        private static int randomNumber; 

        public static Punter GetAPunter(int id)
        {
            switch (id)
            {
                case 0:
                    return new Tom();
                case 1:
                    return new Dick();
                case 2:
                    return new Harry();
            }

            return new Dick();
        }

        public static Punter GetADragon(int id)
        {
            switch (id)
            {
                case 0:
                    return new PolkaDotty();
                case 1:
                    return new Demetrius();
                case 2:
                    return new SparkleDust();
                case 3:
                    return new RainbowBrite();
            }

            return new RainbowBrite();
        }


        public static int Number()
        {
            return randomNumber = Random.Next(0, 30);
        }

    }

    }

