using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSED03;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Randomness()


        {

            race raceTime = new race();

            int actual = Factory.Number();

            Assert.IsTrue(actual > 1 && actual <= 20);
        }

        [TestMethod]
        public void Dragon()


        {

            race raceTime = new race();

            int ID = 2;

            int actual = Convert.ToInt16(Factory.GetADragon(ID).Dragon);

            Assert.IsTrue(actual > 1 && actual <= 3);

        }





    }
}
