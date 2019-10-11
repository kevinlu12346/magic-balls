using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeployShapes : MonoBehaviour
{
    public GameObject Square;
    public GameObject SquareMoney;
    public GameObject Circle;
    public GameObject Diamond;
    public GameObject Triangle1;
    public GameObject Triangle2;

    public GameObject Triangle3;
    public GameObject Triangle4;

    public GameObject Hexagon;
    public GameObject Pentagon;
    public GameObject LargeSquare;
    public GameObject powerBall;
    public GameObject freeze;
    public GameObject speed;

    private GameObject child; // text
    public static bool running = true;
    public GameObject explosion;

    public float respawnTime;
    public float height2;
    public float height1;
    public float spawnHeight;

    public static int nLine = 0;
    public static int spawnPositionForBigShape;
    public static int spawnPositionForPowerUp;
    double[] positionsX = { -2.54, -2.08, -1.62, -1.16, -0.69, -0.23, 0.23, 0.69, 1.16, 1.62, 2.08, 2.54 };

    double positionY = 1.29;

             // Start is called before the first frame update
            void Start()
            {
                int total = getLineTotal();
                int beginHealthRow1 =(int) (total / 12);
                int beginHealthRow2 =  beginHealthRow1 + (int)PlayerController.firePower;

                //----------------------------------------------------------------------------------------------------------------//
                // row 2

                for (int i = 0; i < 12; i++) {
                    GameObject a;

                    a = Instantiate(Square) as GameObject;

                    a.transform.position = new Vector2((float)positionsX[i], height2);
                    a.GetComponent<Shape>().health = beginHealthRow1;
                    child = a.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText((beginHealthRow1.ToString()));
                }


                //----------------------------------------------------------------------------------------------------------------//
                // row 1
                for (int i = 0; i < 12; i++) {
                    GameObject a1 = Instantiate(Square) as GameObject;
                    a1.transform.position = new Vector2((float)positionsX[i], height1);
                    a1.GetComponent<Shape>().health = beginHealthRow1;
                    child = a1.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText((beginHealthRow1.ToString()));
                }

                StartCoroutine(wave());
            }


            void Update() {
                //explosion.GetComponent<ParticleSystem>().Play();
            }



            void spawnShapes()
            {
                 /*
              if(timer <= 15f){
                  timer += Time.deltaTime;
              } else {
                bool specialBlock = true;
              }
              */

              if (nLine % 16 == 0 && nLine > 2) {
                  // spawn big shape
                  spawnPositionForBigShape = Random.Range(1, 11);
                  int total = getLineTotal();

                  GameObject g = Instantiate(LargeSquare) as GameObject;
                  g.transform.position = new Vector2((float)positionsX[spawnPositionForBigShape], spawnHeight + 0.45f);
                  g.GetComponent<Shape>().health = total;
                  child = g.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((total.ToString()));




                  spawnBigShapeLine();
             } else if (nLine % 16 == 1 && nLine > 2) {
                  spawnBigShapeLine();
             } else if (nLine % 16 == 2 && nLine > 2) {
                  spawnBigShapeLine();
              }
               else if (nLine % 16 == 7 && nLine > 16) {
                   // 0 == speed 1 == power 2 == freeze
                   int powerUpType = Random.Range(0, 85);



                   spawnPositionForPowerUp = Random.Range(0, 12);
                   Debug.Log(spawnPositionForPowerUp);
                   int total = getLineTotal();

                   if (powerUpType >= 0 && powerUpType < 30) {
                       GameObject g = Instantiate(speed) as GameObject;
                       g.transform.position = new Vector2((float)positionsX[spawnPositionForPowerUp], spawnHeight);
                       g.GetComponent<Shape>().health =(int)total / 4;
                       child = g.transform.Find("ShapeText").gameObject;
                       child.GetComponent<TextMeshPro>().SetText((((int)total/4).ToString()));
                   } else if (powerUpType >= 31 && powerUpType < 60) {
                       GameObject g = Instantiate(powerBall) as GameObject;
                       g.transform.position = new Vector2((float)positionsX[spawnPositionForPowerUp], spawnHeight);
                       g.GetComponent<Shape>().health =(int)total / 4;
                       child = g.transform.Find("ShapeText").gameObject;
                       child.GetComponent<TextMeshPro>().SetText((((int)total/4).ToString()));
                   } else if (powerUpType >= 61) {
                       GameObject g = Instantiate(freeze) as GameObject;
                       g.transform.position = new Vector2((float)positionsX[spawnPositionForPowerUp], spawnHeight);
                       g.GetComponent<Shape>().health =(int)total / 4;
                       child = g.transform.Find("ShapeText").gameObject;
                       child.GetComponent<TextMeshPro>().SetText((((int)total/4).ToString()));
                   }






                   int[] shapes = new int[12];
                   for (int i = 0; i < 12; i++) {
                     int randomInt = selectShape();
                     shapes[i] = randomInt;
                   }
                   int numShapes = 0;
                   for (int i = 0; i < 12; i++) {
                     if (shapes[i] != 0) {
                       numShapes++;
                     }
                   }

                   int total2 = getLineTotal();
                   int[] healths = generateXNumbersSumToTotal(numShapes, total2);
                   instantiateShapesPowerUp(shapes, healths, spawnPositionForPowerUp);
               }
              else {
                    int[] shapes = new int[12];
                    for (int i = 0; i < 12; i++) {
                      int randomInt = selectShape();
                      shapes[i] = randomInt;
                    }
                    int numShapes = 0;
                    for (int i = 0; i < 12; i++) {
                      if (shapes[i] != 0) {
                        numShapes++;
                      }
                    }

                    int total = getLineTotal();
                    int[] healths = generateXNumbersSumToTotal(numShapes, total);
                    instantiateShapes(shapes, healths);
                }

              nLine++;
            }

            IEnumerator wave() {
              while (running) {
                spawnShapes();
                Debug.Log("dankerino pepperino");
                yield return new WaitForSeconds(respawnTime);
              }
              if (!running) {
                  StartCoroutine(runActivate());
              }
            }
            IEnumerator runActivate() {
                yield return new WaitForSeconds(10f);
                running = true;
                StartCoroutine(wave());
            }

            // spawns small blocks for lines containing large block
            void spawnBigShapeLine() {
                int[] shapes = new int[9];
                for (int i = 0; i < 9; i++) {
                  int randomInt = selectShape();
                  shapes[i] = randomInt;
                }
                int numShapes = 0;
                for (int i = 0; i < 9; i++) {
                  if (shapes[i] != 0) {
                    numShapes++;
                  }
                }

                int total2 = getLineTotal();
                int bigTotal = (int)(total2 * 0.5f);
                int[] healths = generateXNumbersSumToTotal(numShapes, bigTotal);
                instantiateShapes(shapes, healths, spawnPositionForBigShape);
            }


            // generate random shapes
            int selectShape() {
                int roll = Random.Range(0, 101);
                //GameObject randomObject;
                if (roll < 23) {
                  //randomObject = Instantiate(Square) as GameObject;
                  return 1;
              } else if (roll >= 23 && roll < 26) {
                  return 7;
              } else if (roll >= 30 && roll < 39) {
                //  randomObject = Instantiate(Circle) as GameObject;
                  return 2;
              } else if ( roll >= 39 && roll < 50) {
                //  randomObject = Instantiate(Diamond) as GameObject;
                  return 3;
              } else if ( roll >= 50 && roll < 55) {
                  return 4;
                //  randomObject = Instantiate(Pentagon) as GameObject;
            } else if ( roll >= 55 && roll < 60) {
                  return 5;
                //  randomObject = Instantiate(Hexagon) as GameObject;
            } else if ( roll >= 60 && roll < 65) {
                  return 6;
                //  randomObject = Instantiate(Triangle) as GameObject;
            } else if ( roll >= 65 && roll < 70) {

        //large circle
                  return 0;
                } else if ( roll >= 80 || roll < 85) {
        //large Hexagon
                  return 0;
                } else if ( roll >= 85 || roll <= 100) {
                  // empty space
                  return 0;
                }
                return 0;
            }

            void instantiateShapes(int[] shapes, int[] healths) {
              int z = 0;
              for (int i = 0; i < shapes.Length; i++) {
                if(shapes[i] == 0) {
                  continue;
                }

                if (shapes[i] == 1) {
                  GameObject g2 = Instantiate(Square) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i],spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i],spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        }
                } else if (shapes[i] == 7) {
                    GameObject g2 = Instantiate(SquareMoney) as GameObject;
                    g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                    g2.GetComponent<Shape>().health = healths[z];
                    child = g2.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                }
                z++;
              }
            }


            // instantiate shapes where we spawn a 3x3 shape
            void instantiateShapes(int[] shapes, int[] healths, int bigSpawnPosition) {
              int z = 0;
              for (int i = 0; i < shapes.Length; i++) {
                if(shapes[i] == 0 || i == bigSpawnPosition || i== bigSpawnPosition - 1 || i == bigSpawnPosition + 1 ) {
                  continue;
                }

                if (shapes[i] == 1) {
                  GameObject g2 = Instantiate(Square) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        }
                }
                z++;
              }
            }


            void instantiateShapesPowerUp(int[] shapes, int[] healths, int spawnpos) {
              int z = 0;

              for (int i = 0; i < shapes.Length; i++) {
                if(shapes[i] == 0 || i == spawnpos) {

                  continue;
                }

                if (shapes[i] == 1) {
                  GameObject g2 = Instantiate(Square) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText((healths[z].ToString()));

                        }
                }
                z++;
              }
            }

            // get line total
            int getLineTotal() {
                int total = (int)PlayerController.firePowerAlgorithm * (int)PlayerController.PlayerNumBalls * 5;
                return total;
            }
            // returns array of size x that sum to total
            int[] generateXNumbersSumToTotal(int x, int total) {
                int[] numbers = new int[x];
                int currSum = 0;
                total++;
                //Debug.Log("total = " + total);
                //Debug.Log((total - currSum) * 1/2);
                int i = 0;
                  for (i = 0; i < x - 1; i++) {
                    int roll = Random.Range(1, ((total - currSum) * 1/2) );
                    numbers[i] = roll;
                    currSum += roll;
                  }
                  numbers[i] = total - currSum;
                return numbers;
            }



}
