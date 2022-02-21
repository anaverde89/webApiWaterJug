using WebApiWaterJug.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiWaterJug.Controllers
{
    public class StepsController : ApiController
    {
        public IHttpActionResult GetSolution(int x = 0, int y = 0, int z = 0)
        {
            Response response = new Response();
            if (x == 0 || y == 0 || z == 0)
            {
                response.status = "error";
                response.message = "No solution";
                return Ok(response);
            }
            Step[] stepsA = Solve(x, y, z, "bucket x", "bucket y", 1);
            Step[] stepsB = Solve(y, x, z, "bucket y", "bucket x",2);
            if (stepsA != null || stepsB != null)
            {
                response.status = "success";
                if (stepsA.Length > stepsB.Length)
                {
                    response.steps = stepsB;
                }
                else
                {
                    response.steps = stepsA;
                }
            }
            else
            {
                response.status = "error";
                response.message = "No solution";
            }
            return Ok(response);
        }

        private Step[] Solve(int number1, int number2, int total, string bucketA, string bucketB, int pass)
        {
            int a = number1;
            int b = 0;
            int diff;
            string explanation = "Fill " + bucketA;
            List<Step> steps = new List<Step>();
            if (pass == 1)
            {
                steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
            }
            else
            {
                steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
            }
            while (!(a == total || b == total))
            {
                diff = 0;
                if (number1 < number2)
                {
                    if (a + b < number2)
                    {
                        diff = a;
                        b = b + diff;
                        a = a - diff;
                        explanation = "Transfer " + bucketA + " to " + bucketB;
                        if (pass == 1)
                        {
                            steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                        }
                        else
                        {
                            steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                        }
                    }
                    else
                    {
                        diff = number2 - b;
                        if (diff == 0)
                        {
                            b = 0;
                            explanation = "Dump " + bucketB;
                            if (pass == 1)
                            {
                                steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                            }
                            else
                            {
                                steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                            }
                        }
                        else
                        {
                            if (diff > a)
                            {
                                b = b + a;
                                a = 0;
                            }
                            else
                            {
                                b = b + diff;
                                a = a - diff;
                            }
                            explanation = "Transfer " + bucketA + " to " + bucketB;
                            if (pass == 1)
                            {
                                steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                            }
                            else
                            {
                                steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                            }
                        }
                    }
                }
                else
                {
                    diff = Math.Abs(number2 - b);
                    if (diff == 0)
                    {
                        b = 0;
                        explanation = "Dump " + bucketB;
                        if (pass == 1)
                        {
                            steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                        }
                        else
                        {
                            steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                        }
                    }
                    else
                    {
                        if (diff > a)
                        {
                            b = b + a;
                            a = 0;
                        }
                        else
                        {
                            b = b + diff;
                            a = a - diff;
                        }
                        explanation = "Transfer " + bucketA + " to " + bucketB;
                        if (pass == 1)
                        {
                            steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                        }
                        else
                        {
                            steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                        }
                    }
                }
                if (a == 0 && b != total)
                {
                    a = number1;
                    explanation = "Fill " + bucketA;
                    if (pass == 1)
                    {
                        steps.Add(new Step { bucketX = a, bucketY = b, explanation = explanation });
                    }
                    else
                    {
                        steps.Add(new Step { bucketY = a, bucketX = b, explanation = explanation });
                    }
                    if (b == number2)
                    {
                        steps = null;
                        break;
                    }
                }
            }
            if (steps != null)
            {
                return steps.ToArray();
            }
            else
            {
                return null;
            }
        }
    }
}
