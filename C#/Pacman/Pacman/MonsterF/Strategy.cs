using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public abstract class StrategyMove
    {
        public abstract void Move(Monster speedy, MyMap map, Pacaman pacaman);
    }

    public class SpeedyFirstMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);
            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                && speedy.GetCoordMonster().x >= 14 && speedy.GetCoordMonster().x <= 16)
            {
                if (speedy.GetCoordMonster().x == 14)
                {
                    speedy.Direction = 4;
                    speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                }
                else if (speedy.GetCoordMonster().x == 15 || speedy.GetCoordMonster().x == 16)
                {
                    speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                    speedy.Direction = 1;
                }
            }
            else if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (pacaman.GetCoordMonster().y + 3 < speedy.GetCoordMonster().y)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                }
                else if (pacaman.GetCoordMonster().y - 3 > speedy.GetCoordMonster().y)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 1)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 2;
                    }
                    else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                           && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                    }
                }
                else if (pacaman.GetCoordMonster().y - 3 <= speedy.GetCoordMonster().y || pacaman.GetCoordMonster().y + 3 >= speedy.GetCoordMonster().y)
                {
                    if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                    }
                    else if (pacaman.GetCoordMonster().x > speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                           && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                           && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                    }
                }
                //---------------------------------------------------------//
                //----------------   проход через коридор -----------------//
            }
            else
                speedy.Tunnel(map);
            //speedy.Tunnel(map);

            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class SpeedySecondMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                && speedy.GetCoordMonster().x >= 14 && speedy.GetCoordMonster().x <= 16)
            {
                if (speedy.GetCoordMonster().x == 14)
                {
                    speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                    speedy.Direction = 4;
                }
                else if (speedy.GetCoordMonster().x == 15 && speedy.GetCoordMonster().x == 16)
                {
                    speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                    speedy.Direction = 1;
                }
            }
            else if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (speedy.GetCoordMonster().y > 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && speedy.Direction != 2 && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (speedy.GetCoordMonster().x < 1)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1 && speedy.Direction != 4
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1 && speedy.Direction != 1
                          && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1 && speedy.Direction != 3
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1 && speedy.Direction != 4
                           && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1 && speedy.Direction != 1
                           )// && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1 && speedy.Direction != 3
                            )//&& map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y <= 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1 && speedy.Direction != 1
                        )//&& map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 2;
                    }
                    else if (speedy.GetCoordMonster().x <= 1)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1 && speedy.Direction != 4
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1 && speedy.Direction != 2
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1 && speedy.Direction != 3
                           && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1 && speedy.Direction != 4
                          && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1 && speedy.Direction != 2
                          && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1 && speedy.Direction != 3
                           && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                }
            }
            else
                //---------------------------------------------------------//
                //----------------   проход через коридор -----------------//
                speedy.Tunnel(map);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class SpeedyAfraidMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);
            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                && speedy.GetCoordMonster().x >= 14 && speedy.GetCoordMonster().x <= 16)
            {

            }
            else if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (speedy.GetCoordMonster().y > 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (speedy.GetCoordMonster().x >= 1)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                            speedy.Direction = 3;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y == 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                        && speedy.Direction != 4)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        speedy.Direction = 3;
                    }
                    else if (speedy.GetCoordMonster().x != 1)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 2;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            speedy.Direction = 4;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                    }
                }
            }

            //speedy.Tunnel(map);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class RedFirstMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (pacaman.GetCoordMonster().y < speedy.GetCoordMonster().y)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                    }
                }
                else if (pacaman.GetCoordMonster().y > speedy.GetCoordMonster().y)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 1)
                    {
                        speedy.Direction = 2;
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);

                    }
                    else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                    }
                }
                else if (pacaman.GetCoordMonster().y == speedy.GetCoordMonster().y)
                {
                    if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                    }
                    else if (pacaman.GetCoordMonster().x > speedy.GetCoordMonster().x)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                    }
                }
            }
            //---------------------------------------------------------//
            //----------------   проход через коридор -----------------//
            speedy.Tunnel(map);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class RedSecondMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (speedy.GetCoordMonster().y < 2)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (speedy.GetCoordMonster().x <= 31)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y > 5)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 1)
                    {
                        speedy.Direction = 2;
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                    }
                    else if (speedy.GetCoordMonster().x <= 31)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y == 5)
                {
                    if (speedy.GetCoordMonster().x <= 31)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                    }
                    else if (speedy.GetCoordMonster().x > 31)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                    }
                }
            }
            speedy.Tunnel(map);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class RedAfraidMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (speedy.GetCoordMonster().y > 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                        speedy.Direction = 1;
                    }
                    else if (speedy.GetCoordMonster().x <= 29)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y == 1)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                        && speedy.Direction != 3)
                    {
                        speedy.Direction = 4;
                        speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                    }
                    else if (speedy.GetCoordMonster().x != 29)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1);
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.SetCoordMonster(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x);
                            speedy.Direction = 1;
                        }
                    }
                }

            }
            speedy.Tunnel(map);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class BlueFirstMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            ConsoleLib.Coord tmp = speedy.GetCoordMonster();

            speedy.DeleteDraw(map);


            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                            && speedy.GetCoordMonster().x >= 13 && speedy.GetCoordMonster().x <= 16)
            {
                if (tmp.x == 14 || tmp.x == 13)
                {
                    speedy.Direction = 4;
                    //speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                    tmp.x += 1;
                }
                else if (tmp.x == 15 || tmp.x == 16)
                {
                    tmp.y -= 1;
                    speedy.Direction = 1;
                }
                speedy.SetCoordMonster(tmp.y, tmp.x);
            }
            else if (tmp.x - 1 != -1 && tmp.x + 1 != 32)
            {
                if ((pacaman.GetCoordMonster().y + pacaman.GetCoordMonster().x - tmp.y + tmp.x) <= 8
                && (pacaman.GetCoordMonster().y + pacaman.GetCoordMonster().x - tmp.y + tmp.x - 26) <= -8)
                {
                    if (pacaman.GetCoordMonster().y < tmp.y)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            tmp.y -= 1;
                            speedy.Direction = 1;
                        }
                        else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                        else
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                    }
                    else if (pacaman.GetCoordMonster().y > speedy.GetCoordMonster().y)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            tmp.y += 1;

                        }
                        else if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                        else
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                speedy.SetCoordMonster(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1);
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                        }
                    }
                    else if (pacaman.GetCoordMonster().y == speedy.GetCoordMonster().y)
                    {
                        if (pacaman.GetCoordMonster().x <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                        }
                        else if (pacaman.GetCoordMonster().x > speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                        }
                    }
                }
                else
                {
                    if (pacaman.GetCoordMonster().y + 4 < speedy.GetCoordMonster().y)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            tmp.y -= 1;
                            speedy.Direction = 1;
                        }
                        else if (pacaman.GetCoordMonster().x + 4 <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                        else
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                    }
                    else if (pacaman.GetCoordMonster().y - 4 > speedy.GetCoordMonster().y)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            tmp.y += 1;

                        }
                        else if (pacaman.GetCoordMonster().x + 4 <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                        }
                        else
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                        }
                    }
                    else if (pacaman.GetCoordMonster().y - 4 <= speedy.GetCoordMonster().y || pacaman.GetCoordMonster().y + 4 >= speedy.GetCoordMonster().y)
                    {
                        if (pacaman.GetCoordMonster().x + 4 <= speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                        }
                        else if (pacaman.GetCoordMonster().x + 4 > speedy.GetCoordMonster().x)
                        {
                            if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                                && speedy.Direction != 3)
                            {
                                speedy.Direction = 4;
                                tmp.x += 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 2)
                            {
                                speedy.Direction = 1;
                                tmp.y -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                                && speedy.Direction != 4)
                            {
                                speedy.Direction = 3;
                                tmp.x -= 1;
                            }
                            else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                                && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                                && speedy.Direction != 1)
                            {
                                speedy.Direction = 2;
                                tmp.y += 1;
                            }
                        }
                    }
                    //---------------------------------------------------------//
                    //----------------   проход через коридор -----------------//

                }
                speedy.SetCoordMonster(tmp.y, tmp.x);
            }
            else
                speedy.Tunnel(map);

            //speedy.SetCoordMonster(tmp.y, tmp.x);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }

    public class BlueSecondMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            ConsoleLib.Coord tmp = speedy.GetCoordMonster();
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                            && speedy.GetCoordMonster().x >= 14 && speedy.GetCoordMonster().x <= 16)
            {
                if (speedy.GetCoordMonster().x == 14)
                {
                    speedy.Direction = 4;
                    tmp.x += 1;
                }
                else if (speedy.GetCoordMonster().x == 15 || speedy.GetCoordMonster().x == 16)
                {
                    tmp.y -= 1;
                    speedy.Direction = 1;
                }
                speedy.SetCoordMonster(tmp.y, tmp.x);
            }
            else if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                if (speedy.GetCoordMonster().y < 30)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 1)
                    {
                        speedy.Direction = 2;
                        tmp.y += 1;
                    }
                    else if (speedy.GetCoordMonster().x <= pacaman.GetCoordMonster().x - 2)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            tmp.x += 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            tmp.y -= 1;
                            speedy.Direction = 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            tmp.x -= 1;
                        }
                    }
                    else
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            tmp.x -= 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            tmp.y += 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            tmp.x += 1;
                        }
                    }
                }
                else if (speedy.GetCoordMonster().y >= 30)
                {
                    if (speedy.GetCoordMonster().x < pacaman.GetCoordMonster().x - 1)
                    {
                        if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                            && speedy.Direction != 3)
                        {
                            speedy.Direction = 4;
                            tmp.x += 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                            && speedy.Direction != 4)
                        {
                            speedy.Direction = 3;
                            tmp.x -= 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 2)
                        {
                            speedy.Direction = 1;
                            tmp.y -= 1;
                        }
                        else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                            && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                            && speedy.Direction != 1)
                        {
                            speedy.Direction = 2;
                            tmp.y += 1;
                        }
                    }
                }
                speedy.SetCoordMonster(tmp.y, tmp.x);
            }
            else
                speedy.Tunnel(map);
            //speedy.SetCoordMonster(tmp.y, tmp.x);
            speedy.Draw(map);
            speedy.DrawBack(map);
        }

    }

    public class BlueAfraidMove : StrategyMove
    {
        public override void Move(Monster speedy, MyMap map, Pacaman pacaman)
        {
            ConsoleLib.Coord tmp = speedy.GetCoordMonster();
            speedy.DeleteDraw(map);

            if (speedy.GetCoordMonster().y <= 13 && speedy.GetCoordMonster().y >= 12
                            && speedy.GetCoordMonster().x >= 13 && speedy.GetCoordMonster().x <= 16)
            { }
            else if (speedy.GetCoordMonster().x - 1 != -1 && speedy.GetCoordMonster().x + 1 != 32)
            {
                //if (speedy.GetCoordMonster().y < pacaman.GetCoordMonster().y - 2)
                // {
                if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                    && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                    && speedy.Direction != 1)
                {
                    speedy.Direction = 2;
                    tmp.y += 1;
                }
                else if (speedy.GetCoordMonster().x <= pacaman.GetCoordMonster().x - 2)
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                        && speedy.Direction != 3)
                    {
                        speedy.Direction = 4;
                        tmp.x += 1;
                    }
                    else if (map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y - 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 2)
                    {
                        tmp.y -= 1;
                        speedy.Direction = 1;
                    }
                    else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                        && speedy.Direction != 4)
                    {
                        speedy.Direction = 3;
                        tmp.x -= 1;
                    }
                }
                else
                {
                    if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x - 1) != 7
                        && speedy.Direction != 4)
                    {
                        speedy.Direction = 3;
                        tmp.x -= 1;
                    }
                    else if (map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y + 1, speedy.GetCoordMonster().x) != 7
                        && speedy.Direction != 1)
                    {
                        speedy.Direction = 2;
                        tmp.y += 1;
                    }
                    else if (map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 1
                        && map.GetPointInMap(speedy.GetCoordMonster().y, speedy.GetCoordMonster().x + 1) != 7
                        && speedy.Direction != 3)
                    {
                        speedy.Direction = 4;
                        tmp.x += 1;
                    }
                }
                speedy.SetCoordMonster(tmp.y, tmp.x);
            }
            else
                speedy.Tunnel(map);

            speedy.Draw(map);
            speedy.DrawBack(map);
        }
    }



}
