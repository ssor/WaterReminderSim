using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterReminderSim
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("请喝点水吧！记住喝完水把杯子放在这，你输入的数值是杯子里剩下的水量");
            Console.WriteLine(string.Format("你使用的杯子的最大容量是 {0} 毫升，你的总目标是 {1} 毫升"
                , WR.MAX_V_OF_BOTTLE.ToString()
                , WR.GOAL_V.ToString()));
            Console.WriteLine();
            int v = 0;
            string line;
        LOOP: line = Console.ReadLine();
            try
            {
                v = int.Parse(line);
                if (v >= 0 && v <= WR.MAX_V_OF_BOTTLE)
                {
                    WR.NewWaterDataInput(v);

                    PrintCurrentState();
                }
                else
                {
                    Console.WriteLine("你用的杯子好奇怪啊，我没法测算！");
                }
                goto LOOP;

            }
            catch
            {
                goto LOOP;
            }
        }

        private static void PrintCurrentState()
        {
            int rest = WR.GOAL_V - WR.currentV;
            if (rest > 0)
            {
                Console.WriteLine(string.Format("你已经喝了 {0} 毫升 水，还得喝 {1} 毫升"
                    , WR.currentV.ToString()
                    , rest.ToString()));
            }
            else
            {
                Console.WriteLine(string.Format("你已经喝了 {0} 毫升 水，足够了！"
                    , WR.currentV.ToString()));
            }
        }

    }
    public class WR
    {

        public static int GOAL_V = 3000;//目标水量
        public static int DEFAULT_V_OF_BOTTLE = 250;//默认杯子的容量
        public static int MAX_V_OF_BOTTLE = 280;
        public static int MIN_V_IN_BOTTLE = 0;
        public static int IGNORE_V = 5;//如果杯子前后两次的水量差距在此范围内，就认为相同

        public static int lastVofBottle = 0;//杯子中上次的剩余量
        public static int currentV = 0;//已经喝完的水量
        /// <summary>
        /// 有新数据传递进来，系统要甄别各种情况
        /// 1.杯子只是被拿起又放下
        /// 2.杯子拿起，喝了一部分，或者喝完
        /// 3.杯子里的水被喝完（这个不一定），又被重新灌满
        /// </summary>
        /// <param name="_n"></param>
        public static void NewWaterDataInput(int _n)
        {
            //刚开始
            if (lastVofBottle == -1)
            {
                //放上满满的一杯水,认为没喝
                if (_n >= DEFAULT_V_OF_BOTTLE)
                {
                    lastVofBottle = _n;
                    return;
                }

            }
            else//
            {
                //如果上次和这次的水量差距在误差范围内，则不处理
                if (Math.Abs(_n - lastVofBottle) <= IGNORE_V)
                {
                    return;
                }
                //杯子里的水喝完了
                if (_n <= MIN_V_IN_BOTTLE)
                {
                    currentV += lastVofBottle;
                    lastVofBottle = 0;
                    return;
                }
                //杯子里的水装满了
                if (_n >= DEFAULT_V_OF_BOTTLE)
                {
                    currentV += lastVofBottle;
                    lastVofBottle = _n;
                    return;
                }
                //杯子里水只有一部分
                if (_n < DEFAULT_V_OF_BOTTLE && _n > MIN_V_IN_BOTTLE)
                {
                    if (_n < lastVofBottle)
                    {
                        currentV += (lastVofBottle - _n);
                        lastVofBottle = _n;
                    }
                    else
                    {
                        currentV += (DEFAULT_V_OF_BOTTLE - _n);
                        lastVofBottle = _n;
                        return;
                    }
                }

                //上次根本没有水
                if (lastVofBottle <= MIN_V_IN_BOTTLE)
                {
                    lastVofBottle = _n;
                    return;
                }

                //上次杯子里还有水，那就得比较当前的具体水量了
                if (lastVofBottle > 0)
                {
                    //如果当前的水量比上次的水量小，就认为喝了一部分

                    //如果当前的水量比上次的多，就认为之前的喝完，并且新灌满了一杯

                }
            }
        }


        public static void AddTempV(int _v)
        {

        }
        public static int GetAverageV()
        {
            return 0;
        }
        #region Helper
        public static void ReturnToInitialState()
        {
            currentV = 0;
            lastVofBottle = 0;
        }
        public static void AddV(int _addV)
        {
            currentV += _addV;
        }
        public static int GetRestWater()
        {
            return GOAL_V - currentV;
        }
        #endregion
    }
}
