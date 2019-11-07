using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DeployShapes : MonoBehaviour
{

    private float exp = 6;
    public GameObject Square;
    public GameObject SquareMoney;
    public GameObject Circle;
    public GameObject Diamond;
    public GameObject Triangle1;
    public GameObject Triangle2;
    public GameObject LargeCircle;

    public GameObject Triangle3;
    public GameObject Triangle4;

    public GameObject Hexagon;
    public GameObject Pentagon;
    public GameObject LargeSquare;
    public GameObject powerBall;
    public GameObject freeze;
    public GameObject speed;
    public GameObject normalCircle;

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

    List<Color> colors = new List<Color>();
    public GameObject[] explosions;
    public GameObject[] largeExplosions;
    List<GameObject> explosionList = new List<GameObject>();
    List<GameObject> largeExplosionList = new List<GameObject>();

    double positionY = 1.29;
            void Awake() {
                // set themes
                if (SceneTransition.currTheme == "colorful") {
                    colors.Add(new Color32(13,255,0,255)); // green
                    colors.Add(new Color32(255,124,0,255)); // orange
                    colors.Add(new Color32(0,215,255,255)); // cyan
                    colors.Add(new Color32(255,0,230,255)); // pink
                    colors.Add(new Color32(247,255,0,255)); // yellow
                    colors.Add(new Color32(255,0,0,255)); // red original

                    explosionList.Add(explosions[0]);
                    explosionList.Add(explosions[1]);
                    explosionList.Add(explosions[2]);
                    explosionList.Add(explosions[3]);
                    explosionList.Add(explosions[4]);
                    explosionList.Add(explosions[11]);

                    largeExplosionList.Add(largeExplosions[0]);
                    largeExplosionList.Add(largeExplosions[1]);
                    largeExplosionList.Add(largeExplosions[2]);
                    largeExplosionList.Add(largeExplosions[3]);
                    largeExplosionList.Add(largeExplosions[4]);
                    largeExplosionList.Add(largeExplosions[11]);

                } else if (SceneTransition.currTheme == "white") {
                    colors.Add(new Color32(255,255,255,255)); // white
                    explosionList.Add(explosions[5]);
                    largeExplosionList.Add(largeExplosions[5]);

                } else if (SceneTransition.currTheme == "blue") {
                    colors.Add(new Color32(0,0,255,255)); // blue original
                    colors.Add(new Color32(0,63,255,255)); // blue
                    colors.Add(new Color32(0,127,255,255)); // blue
                    colors.Add(new Color32(0,189,255,255)); // blue
                    colors.Add(new Color32(0,255,255,255)); // blue
                    explosionList.Add(explosions[6]);
                    explosionList.Add(explosions[7]);
                    explosionList.Add(explosions[8]);
                    explosionList.Add(explosions[9]);
                    explosionList.Add(explosions[10]);
                    largeExplosionList.Add(largeExplosions[6]);
                    largeExplosionList.Add(largeExplosions[7]);
                    largeExplosionList.Add(largeExplosions[8]);
                    largeExplosionList.Add(largeExplosions[9]);
                    largeExplosionList.Add(largeExplosions[10]);
                } else if (SceneTransition.currTheme == "red") {
                    colors.Add(new Color32(255,0,0,255)); // red original
                    colors.Add(new Color32(255,0,63,255));
                    colors.Add(new Color32(255,0,127,255));
                    colors.Add(new Color32(255,0,189,255));
                    colors.Add(new Color32(255,0,255,255));
                    explosionList.Add(explosions[11]);
                    explosionList.Add(explosions[12]);
                    explosionList.Add(explosions[13]);
                    explosionList.Add(explosions[14]);
                    explosionList.Add(explosions[15]);
                    largeExplosionList.Add(largeExplosions[11]);
                    largeExplosionList.Add(largeExplosions[12]);
                    largeExplosionList.Add(largeExplosions[13]);
                    largeExplosionList.Add(largeExplosions[14]);
                    largeExplosionList.Add(largeExplosions[15]);
                } else if (SceneTransition.currTheme == "wood") {
                    colors.Add(new Color32(107,142,35,255)); // green original
                    colors.Add(new Color32(85, 107,47,255));
                    colors.Add(new Color32(128,128,0,255));
                    colors.Add(new Color32(46,139,87,255));
                    colors.Add(new Color32(34,139,34,255)); // forest green
                    colors.Add(new Color32(139,69,19,255)); // saddlebrown

                    explosionList.Add(explosions[16]);
                    explosionList.Add(explosions[17]);
                    explosionList.Add(explosions[18]);
                    explosionList.Add(explosions[19]);
                    explosionList.Add(explosions[20]);
                    explosionList.Add(explosions[21]);

                    largeExplosionList.Add(largeExplosions[16]);
                    largeExplosionList.Add(largeExplosions[17]);
                    largeExplosionList.Add(largeExplosions[18]);
                    largeExplosionList.Add(largeExplosions[19]);
                    largeExplosionList.Add(largeExplosions[20]);
                    largeExplosionList.Add(largeExplosions[21]);

                }


            }
            int randomColor(int x, int y) {
                int colorIndex = Random.Range(x,y);
                return colorIndex;
            }
             // Start is called before the first frame update
            void Start()
            {
                exp = 6;
                nLine = 0;
                running = true;
                Circle.transform.Find("ball").GetComponent<SpriteRenderer>().color = Target.bullet.GetComponent<SpriteRenderer>().color;
                Circle.transform.Find("ball").GetComponent<SpriteRenderer>().sprite = Target.bullet.GetComponent<SpriteRenderer>().sprite;

                Time.timeScale = 1f;
                int total = firstRowFromBase();
                //int beginHealthRow1 =(int) (total / 12);
                int beginHealthRow1 = total;
                //----------------------------------------------------------------------------------------------------------------//
                // row 2

                for (int i = 0; i < 12; i++) {
                    GameObject a;

                    a = Instantiate(Square) as GameObject;
                    int randColor = randomColor(0, colors.Count);

                    // set color of shape
                    a.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                    // set explosion of shape
                    //Debug.Log(explosionList.Count);
                    a.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);

                    a.transform.position = new Vector2((float)positionsX[i], height2);
                    a.GetComponent<Shape>().health = beginHealthRow1;
                    child = a.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText(( AbbrevationUtility.AbbreviateNumber(beginHealthRow1)));
                }


                //----------------------------------------------------------------------------------------------------------------//
                // row 1
                for (int i = 0; i < 12; i++) {
                    GameObject a1 = Instantiate(Square) as GameObject;
                    int randColor = randomColor(0, colors.Count);
                    a1.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                    a1.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);

                    a1.transform.position = new Vector2((float)positionsX[i], height1);
                    a1.GetComponent<Shape>().health = beginHealthRow1;
                    child = a1.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText(AbbrevationUtility.AbbreviateNumber(beginHealthRow1));
                }

                StartCoroutine(wave());
            }


            void Update() {
                //explosion.GetComponent<ParticleSystem>().Play();
                //Circle.transform.Find("ball").GetComponent<SpriteRenderer>().color = Target.bullet.GetComponent<SpriteRenderer>().color;

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
                  int x = Random.Range(0,2);
                  // spawn big shape
                  spawnPositionForBigShape = Random.Range(1, 11);
                  int total = getLineTotal();
                  total = (int)(total * 1.5f);
                  GameObject g;
                  if (x == 0) {
                        g = Instantiate(LargeSquare) as GameObject;
                  } else {
                        g = Instantiate(LargeCircle) as GameObject;
                  }
                   int randColor = randomColor(0, colors.Count);
                  g.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g.GetComponent<Shape>().largeExplosion = largeExplosions.ElementAt(randColor);

                  g.transform.position = new Vector2((float)positionsX[spawnPositionForBigShape], spawnHeight + 0.45f);
                  g.GetComponent<Shape>().health = total;
                  child = g.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(AbbrevationUtility.AbbreviateNumber(total));




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
                       child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(((int)total/4))  );
                   } else if (powerUpType >= 30 && powerUpType < 60) {
                       GameObject g = Instantiate(powerBall) as GameObject;
                       g.transform.position = new Vector2((float)positionsX[spawnPositionForPowerUp], spawnHeight);
                       g.GetComponent<Shape>().health =(int)total / 4;
                       child = g.transform.Find("ShapeText").gameObject;
                       child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(((int)total/4))  );
                   } else if (powerUpType >= 61) {
                       GameObject g = Instantiate(freeze) as GameObject;
                       g.transform.position = new Vector2((float)positionsX[spawnPositionForPowerUp], spawnHeight);
                       g.GetComponent<Shape>().health =(int)total / 4;
                       child = g.transform.Find("ShapeText").gameObject;
                       child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(((int)total/4))  );
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
                   int[] healths = generateXNumbersSumToTotal(numShapes, total2 * 3);
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
                    if (nLine % 16 == 3 && nLine > 16 ) {
                        total = total * 2;
                    } else if (nLine % 16 == 9 && nLine > 16) {
                        total = total * 2;
                    }
                    /*
                    if (nLine == 9) {
                        total = (int)(total * 1.5f);
                    }
                    */
                    int[] healths = generateXNumbersSumToTotal(numShapes, total);
                    instantiateShapes(shapes, healths);
                }

              nLine++;
            }

            IEnumerator wave() {
              while (running) {
                spawnShapes();
                //Debug.Log("dankerino pepperino");
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
                int bigTotal = (int)(total2 * 1f);
                int[] healths = generateXNumbersSumToTotal(numShapes, bigTotal);
                instantiateShapes(shapes, healths, spawnPositionForBigShape);
            }


            // generate random shapes
            int selectShape() {
                int roll = Random.Range(0, 105);



            if (roll < 23) {
                  //randomObject = Instantiate(Square) as GameObject;
                  return 1;
              } else if (roll >= 23 && roll < 26) {
                  return 7;
              } else if (roll >= 26 && roll < 31) {
                //  randomObject = Instantiate(Circle) as GameObject;
                  return 2;
              }  else if (roll >= 35 && roll < 39){
                  return 8;
                  // normal circle
              }else if ( roll >= 40 && roll < 50) {
                //  randomObject = Instantiate(Diamond) as GameObject;
                  return 3;
              } else if ( roll >= 50 && roll < 55) {
                  return 4;
                //  randomObject = Instantiate(Pentagon) as GameObject;
            } else if ( roll >= 55 && roll < 60) {
                  return 5;
                //  randomObject = Instantiate(Hexagon) as GameObject;
            } else if ( roll >= 60 && roll < 70) {
                  return 6;
                //  randomObject = Instantiate(Triangle) as GameObject;
            } else if ( roll >= 70 && roll <= 100) {
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
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i],spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i],spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        }
                } else if (shapes[i] == 7) {
                    GameObject g2 = Instantiate(SquareMoney) as GameObject;
                    int randColor = randomColor(0, colors.Count);
                    g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                    g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                    g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                    g2.GetComponent<Shape>().health = healths[z];
                    child = g2.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 8) {
                    GameObject g2 = Instantiate(normalCircle) as GameObject;
                    int randColor = randomColor(0, colors.Count);
                    g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                    g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                    g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                    g2.GetComponent<Shape>().health = healths[z];
                    child = g2.transform.Find("ShapeText").gameObject;
                    child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
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
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

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
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 2) {
                  GameObject g2 = Instantiate(Circle) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 3) {
                  GameObject g2 = Instantiate(Diamond) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 4) {
                  GameObject g2 = Instantiate(Pentagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 5) {
                  GameObject g2 = Instantiate(Hexagon) as GameObject;
                  int randColor = randomColor(0, colors.Count);
                  g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                  g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);

                  g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                  g2.GetComponent<Shape>().health = healths[z];
                  child = g2.transform.Find("ShapeText").gameObject;
                  child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );
                } else if (shapes[i] == 6) {
                        int roll = Random.Range(0, 4);
                        if (roll == 0) {
                        GameObject g2 = Instantiate(Triangle1) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 1) {
                        GameObject g2 = Instantiate(Triangle2) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 2) {
                        GameObject g2 = Instantiate(Triangle3) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        } else if (roll == 3) {
                        GameObject g2 = Instantiate(Triangle4) as GameObject;
                        int randColor = randomColor(0, colors.Count);
                        g2.GetComponent<SpriteRenderer>().color = colors.ElementAt(randColor);
                        g2.GetComponent<Shape>().explosion = explosionList.ElementAt(randColor);
                        g2.transform.position = new Vector2((float)positionsX[i], spawnHeight);
                        g2.GetComponent<Shape>().health = healths[z];
                        child = g2.transform.Find("ShapeText").gameObject;
                        child.GetComponent<TextMeshPro>().SetText(  AbbrevationUtility.AbbreviateNumber(healths[z]) );

                        }
                }
                z++;
              }
            }

            // get line total
            int getLineTotal() {
                // max balls you can shoot out per second
                float maxBallsPerSecond = 1/UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1] ;

                //Debug.Log("max is " + maxBallsPerSecond + "D" +UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1] );
                int left = PlayerController.leftNumberBalls;
                int middle = PlayerController.numberBalls;
                int right = PlayerController.rightNumberBalls;



                // if you have more balls than maxballspersecond then the formula only takes into acoutn dps and doesnt disqualify you for extra balls you have
                if (PlayerController.leftNumberBalls > maxBallsPerSecond) {
                    left = (int)maxBallsPerSecond;
                } else {
                    // else if balls is less than max use less number balls for algorithm
                    left = PlayerController.leftNumberBalls;
                }
                if (PlayerController.rightNumberBalls > maxBallsPerSecond) {
                    right =(int) maxBallsPerSecond;
                } else {
                    right = PlayerController.rightNumberBalls;
                }
                if (PlayerController.numberBalls > maxBallsPerSecond) {
                    middle =(int) maxBallsPerSecond;
                } else {
                    middle = PlayerController.numberBalls;
                }


                //int total = (int)PlayerController.firePowerAlgorithm * ((int)PlayerController.numberBalls + PlayerController.leftNumberBalls + PlayerController.rightNumberBalls);
                //Debug.Log(total + "total is ");
                //return  total   * 2 * 3;
                float dps = (left + right + middle ) * (float)PlayerController.firePowerAlgorithm;
                //DPS = total balls you can shoot[1/fr or if less than 1/fr total balls] /s (30) * damage (5) = 150 dps
/*
                if (dps < 30) {
                    dps = 30f;
                }
    */
                float currExp = exp;
                if (nLine > 105) {
                    exp += 0.16f;
                }
                else if (nLine > 51) {
                    exp += 0.13f;
                } else if (nLine > 32) {
                    exp += 0.11f;
                }
                else {
                    exp += 0.08f;
                }

                Debug.Log((int)(dps * currExp) + "d"  + exp + "lien is " + nLine);

                return (int)(dps * exp * 0.95 * 1.5); // * 2 for double ball movement speed
                //int scaledDPS = convertDPSfromBase((int)dps);
                //return (int)(scaledDPS * exp);

            }

            int convertDPSfromBase(int dps) {
                int newDPS = (int)((dps/5) * 30);
                return newDPS;
            }

            // returns array of size x that sum to total
            int[] generateXNumbersSumToTotal(int x, int total) {
                if (x == 0) {
                    return null;
                }
                int[] numbers = new int[x];
                int currSum = 0;
                //total++; // for random range as max is exclusive
                //Debug.Log("total = " + total);
                //Debug.Log((total - currSum) * 1/2);
                int i = 0;
                  for (i = 0; i < x - 1; i++) {
                    int roll = Random.Range(1, ((total - currSum) * 1/2) );
                    //Debug.Log((total - currSum) * 1/2);


                    numbers[i] = roll;
                    currSum += roll;
                  }
                  if (currSum >= total) {
                      numbers[i] = (int)(total/12);
                  } else {
                      numbers[i] = total - currSum;
                  }

                  // uniform distribution largest numbers (0)
                  if (x > 1) {
                      int newIndex = Random.Range(0,x);

                      int temp = numbers[newIndex];
                      numbers[newIndex] = numbers[0];
                      numbers[0] = temp;
                  }


                return numbers;
            }



                 public static class AbbrevationUtility
                 {
                     private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>
                     {
                         {1000,"K"},
                         {1000000, "M" },
                         {1000000000, "B" },
                         {1000000000000,"T"}
                     };

                     public static string AbbreviateNumber(float number)
                     {
                         if (number >= 10000) {
                             for (int i = abbrevations.Count - 1; i >= 0; i--)
                             {
                                 KeyValuePair<long, string> pair = abbrevations.ElementAt(i);
                                 if (Mathf.Abs(number) >= pair.Key)
                                 {
                                     int roundedNumber = Mathf.FloorToInt(number / pair.Key);
                                     return roundedNumber.ToString() + pair.Value;
                                 }
                             }
                         }
                         return number.ToString();
                     }
                 }

                 int firstRowFromBase() {

                     float maxBallsPerSecond = 1/UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1] ;

                     //Debug.Log("max is " + maxBallsPerSecond + "D" +UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1] );
                     int left = PlayerController.leftNumberBalls;
                     int middle = PlayerController.numberBalls;
                     int right = PlayerController.rightNumberBalls;



                     // if you have more balls than maxballspersecond then the formula only takes into acoutn dps and doesnt disqualify you for extra balls you have
                     if (PlayerController.leftNumberBalls > maxBallsPerSecond) {
                         left = (int)maxBallsPerSecond;
                     } else {
                         // else if balls is less than max use less number balls for algorithm
                         left = PlayerController.leftNumberBalls;
                     }
                     if (PlayerController.rightNumberBalls > maxBallsPerSecond) {
                         right =(int) maxBallsPerSecond;
                     } else {
                         right = PlayerController.rightNumberBalls;
                     }
                     if (PlayerController.numberBalls > maxBallsPerSecond) {
                         middle =(int) maxBallsPerSecond;
                     } else {
                         middle = PlayerController.numberBalls;
                     }


                     //int total = (int)PlayerController.firePowerAlgorithm * ((int)PlayerController.numberBalls + PlayerController.leftNumberBalls + PlayerController.rightNumberBalls);
                     //Debug.Log(total + "total is ");
                     //return  total   * 2 * 3;
                     float dps = (left + right + middle ) * (float)PlayerController.firePowerAlgorithm ;
                     // base is 5dps = 2 so scale it up
                     float scaledDps = dps / 5f;
                     //Debug.Log("scaleddps is " + scaledDps);
                     int total = (int)(scaledDps * 2);
                     return (int)(total * 1.5f);
                 }
}
