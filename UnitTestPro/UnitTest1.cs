using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterReminderSim;

namespace UnitTestPro
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AverageVTest()
        {
            WR.AddTempV(0);
            Assert.IsTrue(0 == WR.GetAverageV());
        }
        //void AddTempV
        [TestMethod]
        public void InitialStateTest1()
        {
            WR.ReturnToInitialState();
            //int newWater = 100;
            int restWater = WR.GetRestWater();
            int someWater = WR.IGNORE_V + 10;

            //放上满满的一杯水
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE);
            Assert.IsTrue(WR.GOAL_V == restWater);
            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - WR.IGNORE_V);
            Assert.IsTrue(WR.GOAL_V == restWater);
            //喝完一杯水
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            restWater = WR.GOAL_V - WR.DEFAULT_V_OF_BOTTLE;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //空杯子拿起来又放下
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //放上一杯不满的水，说明已经喝过几口
            int gap = 100;
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());
            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //稍微喝几口，不喝完
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - someWater);
            restWater = restWater - someWater;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上一杯不满的水，比上面那杯多一点
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());


            //再放上满满的一杯水，说明把上一杯喝完了
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE);
            restWater = restWater - (WR.DEFAULT_V_OF_BOTTLE - gap);
            Assert.IsTrue(WR.GetRestWater() == restWater);

            //放上一杯不满的水，说明已经喝过几口
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

        }

        [TestMethod]
        public void InitialStateTest2()
        {
            WR.ReturnToInitialState();
            int restWater = WR.GetRestWater();
            int gap = 100;
            int someWater = WR.IGNORE_V + 10;

            //放上一杯不满的水,认为已经喝了几口
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //稍微喝几口，不喝完
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - someWater);
            restWater = restWater - someWater;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上一杯不满的水，比上面那杯多一点
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上满满的一杯水，说明把上一杯喝完了
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE);
            restWater = restWater - (WR.DEFAULT_V_OF_BOTTLE - gap);
            Assert.IsTrue(WR.GetRestWater() == restWater);

            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - WR.IGNORE_V);
            Assert.IsTrue(WR.GetRestWater() == restWater);

            //喝完一杯水
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            restWater = restWater - WR.DEFAULT_V_OF_BOTTLE;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //空杯子拿起来又放下
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //放上一杯不满的水,认为已经喝了几口
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //喝完一杯水
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            restWater = restWater - (WR.DEFAULT_V_OF_BOTTLE - gap);
            Assert.IsTrue(restWater == WR.GetRestWater());
        }


        [TestMethod]
        public void InitialStateTest3()
        {
            WR.ReturnToInitialState();
            int restWater = WR.GetRestWater();
            int gap = 100;
            int someWater = WR.IGNORE_V + 10;

            //放上一个空杯子
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //空杯子拿起又放下
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            Assert.IsTrue(restWater == WR.GetRestWater());
            //空杯子拿起又放下
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //放上一杯不满的水,认为已经喝了几口
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //稍微喝几口，不喝完
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap - someWater);
            restWater = restWater - someWater;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上一杯不满的水，比上面那杯多一点
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - gap);
            restWater = restWater - gap;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上满满的一杯水，说明把上一杯喝完了
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE);
            restWater = restWater - (WR.DEFAULT_V_OF_BOTTLE - gap);
            Assert.IsTrue(WR.GetRestWater() == restWater);

            //拿起来又放下
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE - WR.IGNORE_V);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //喝完一杯水
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            restWater = restWater - WR.DEFAULT_V_OF_BOTTLE;
            Assert.IsTrue(restWater == WR.GetRestWater());

            //空杯子拿起来又放下
            WR.NewWaterDataInput(WR.MIN_V_IN_BOTTLE);
            Assert.IsTrue(restWater == WR.GetRestWater());

            //再放上满满的一杯水，说明把上一杯喝完了
            WR.NewWaterDataInput(WR.DEFAULT_V_OF_BOTTLE);
            Assert.IsTrue(WR.GetRestWater() == restWater);
        }
        public void AddRandomWaterTest()
        {

        }

    }
}
