using System.Collections.Generic;
using UnityEngine;

namespace ZinklofDev.Utils.Mapping
{
    /// <summary>
    /// Class <c>PerlinMap</c> is used to save the values that are useful in mapping with perlin noise, including things like the min and max height of your map, and the map itself.
    /// <summary>
    public class PerlinMap
    {
        public float[,] map { get; private set; }
        public float maxMapHeight { get; private set; }
        public float minMapHeight { get; private set; }
        public int64 seed { get; private set; }
        
        public PerlinNoiseMap(float[,] map, float maxMapHeight, float minMapHeight)
        {
            this.map = map;
            this.maxMapHeight = maxMapHeight;
            this.minMapHeight = minMapHeight;
        }

        public PerlinNoiseMap(float[,] map, float maxMapHeight, float minMapHeight, int64 seed)
        {
            this.map = map;
            this.maxMapHeight = maxMapHeight;
            this.minMapHeight = minMapHeight;
            this.seed = seed;
        }

        public void ChangeMapValue(float x, float y, float newValue)
        {
            if (newValue > maxMapHeight)
            {
                maxMapHeight = newValue;
            }
            else if (newValue < minMapHieght)
            {
                minMapHeight = newValue;
            }
            map[x,y] = newValue;
        }
    }   

    /// <summary>
    /// Class <c>Noise</c> provides functions that work in twine with UnityEngine to help make maps out of various noise methods like Perlin Noise.
    /// </summary>
    public static class Noise
    {
        /// <summary>
        /// This generates perlin noise, then directly maps the perlin noise to a 2D float array, useful for perlin noise terrain generation, or generating a texture.
        /// the width and height will directly translate to pixels if used to create a 2D texture, or roughly to the vert ID if used for a uniform plane
        /// if you have a non uniform plane, or want to use this on a 3D shape, it is highly reccommended to use this to make a large (2/4k) texture to sample point height from.
        /// <c>POTTENTIALLY SLOW FUNCTION, GENERATE ONCE THEN USE</c>
        /// </summary>
        /// <param name="width">how many points in the 2D x dimension.</param>
        /// <param name="height">how many points in the 2D y dimension.</param>
        /// <param name="seed">Seed used to change re-randomize the generated noise, or get the exact same again.</param>
        /// <param name="scale">used to change how large or small the image used to make the point map is</param>
        /// <param name="octaves">Changes how many layers of perlin noise to layer/sample, results in more detail</param>
        /// <param name="persistance">above 0 - 1, changes how persistant your amplitude is per octave</param>
        /// <param name="lacunarity">greater than 1, changes how much greater the frequency is per octave (how much smaller the details get)</param>
        /// <param name="offset">the offset by pixels that the perlin noise has, used to shift the map if you want to make multiple chunks</param>
        /// <returns>A 2d float array / float[]</returns>
        public static float[,] GenPerlinNoiseMap(int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
        {
            float[,] noiseMap = new float[width, height];

            System.Random rand = new System.Random(seed);
            Vector2[] octaveOffsets = new Vector2[octaves];

            float maxPossibleHieght = 0;
            float amplitude = 1;
            float frequency = 1;

            for (int i = 0; i < octaves; i++)
            {
                float offsetX = rand.Next(-100000, 100000) + offset.x;
                float offsetY = rand.Next(-100000, 100000) - offset.y;
                octaveOffsets[i] = new Vector2(offsetX, offsetY);

                maxPossibleHieght += amplitude;
                amplitude *= persistance;
            }

            if (scale <= 0)
            {
                Debug.LogWarning("zinklofdev.utils.noise.GenPerlinNoiseMap: Scale must be larger than zero, autoclamped to 0.0001f");
                scale = 0.0001f;
            }

            float maxLocalNoiseHeight = float.MinValue;
            float minLocalNoiseHeight = float.MaxValue;

            float halfWidth = width / 2f;
            float halfHeight = height / 2f;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    amplitude = 1;
                    frequency = 1;
                    float noiseHeight = 0;

                    for (int i = 0; i < octaves; i++)
                    {
                        float sampleX = (x - halfWidth + octaveOffsets[i].x) / scale * frequency;
                        float sampleY = (y - halfHeight + octaveOffsets[i].y) / scale * frequency;

                        float perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                        noiseHeight += perlinNoiseValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    if (noiseHeight > maxLocalNoiseHeight)
                    {
                        maxLocalNoiseHeight = noiseHeight;
                    }
                    else if (noiseHeight < minLocalNoiseHeight)
                    {
                        minLocalNoiseHeight = noiseHeight;
                    }

                    noiseMap[x, y] = noiseHeight;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float normalizedHeight = (noiseMap[x, y] + 1) / (2f * maxPossibleHieght / 1.75f);
                    noiseMap[x, y] = normalizedHeight;
                }
            }

            return noiseMap;
        }

        public PerlinMap GenPerlinMap(int width, int height, float scale, int octaves, float persistance, float lacunarity, vector2 offset)
        {
            if (scale <= 0)
            {
                Debug.LogWarning("Zinklofdev.Utils.Mapping.Noise.GenPerlinMap: You cannot have a zero or less scale, clamping to 0.001f");
                scale = 0.001f;
            }
            
            float[,] noiseMap;
            System.Random rand = new System.Random;
            Vector2[] octaveOffsets = new Vector2[octaves];
            
            float maxPossibleHeight;
            float returnedMaxHeight;
            float returnedMinHeight;

            float amplitude = 1;
            float frequency = 1;

            for (int i = 0; i < octaves; i++)
            {
                float offsetX = rand.Next(-100000, 100000) + offset.x;
                float offsetY = rand.Next(-100000, 100000) - offset.y;
                octaveOffsets[i] = new Vector2(offsetX, offsetY);

                maxPossibleHieght += amplitude;
                amplitude *= persistance;
            }

            float maxLocalNoiseHeight = float.MinValue;
            float minLocalNoiseHeight = float.MaxValue;

            float halfWidth = width / 2f;
            float halfHeight = height / 2f;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    amplitude = 1;
                    frequency = 1;
                    float noiseHeight = 0;

                    for (int i = 0; i < octaves; i++)
                    {
                        float sampleX = (x - halfWidth + octaveOffsets[i].x) / scale * frequency;
                        float sampleY = (y - halfHeight + octaveOffsets[i].y) / scale * frequency;

                        float perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                        noiseHeight += perlinNoiseValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    if (noiseHeight > returnedMaxHeight)
                    {
                        returnedMaxHeight = noiseHeight;
                    }
                    else if (noiseHeight < returnedMinHeight)
                    {
                        returnedMinHeight = noiseHeight;
                    }

                    if (noiseHeight > maxLocalNoiseHeight)
                    {
                        maxLocalNoiseHeight = noiseHeight;
                    }
                    else if (noiseHeight < minLocalNoiseHeight)
                    {
                        minLocalNoiseHeight = noiseHeight;
                    }

                    noiseMap[x, y] = noiseHeight;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float normalizedHeight = (noiseMap[x, y] + 1) / (2f * maxPossibleHieght / 1.75f);
                    noiseMap[x, y] = normalizedHeight;
                }
            }

            PerlinMap map = new PerlinMap(noiseMap, returnedMaxHeight, returnedMinHeight, seed);
            return map;
        }

        /// <summary>
        /// uses the Poisson Disc Sampling method to provide a list of vector2 / points that can be used for various fairly uncommon needs.
        /// made to help me generate a non uniform plane that can be used for low poly map generation. <c>EXTREMELY SLOW FUNCTION, GENERATE ONCE THEN USE</c>
        /// </summary>
        /// <param name="radius">how far away from another point a point can be</param>
        /// <param name="regionSize">how large the region is</param>
        /// <param name="accuracy">how many samples the algorithm does before giving up on a potential point, a low number can ruin the effect. too many gets very expensive.</param>
        /// <returns>A List of Vector 2s</returns>
        public static List<Vector2> PoissonDiscSamplingVector2(float radius, Vector2 regionSize, int accuracy = 30)
        {
            System.Random rand = new System.Random();

            float cellSize = radius / Mathf.Sqrt(2);

            int[,] grid = new int[Mathf.CeilToInt(regionSize.x / cellSize), Mathf.CeilToInt(regionSize.y / cellSize)];
            List<Vector2> points = new List<Vector2>();
            List<Vector2> spawnPoints = new List<Vector2>();

            spawnPoints.Add(regionSize / 2);
            while (spawnPoints.Count > 0)
            {
                int spawnIndex = rand.Next(0, spawnPoints.Count);
                Vector2 spawnCenter = spawnPoints[spawnIndex];
                bool candidateAccepted = false;

                for (int i = 0; i < accuracy; i++)
                {
                    float angle = (float)rand.NextDouble() * 3.1414592f * 2;
                    Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
                    Vector2 candidate = spawnCenter + dir * (float)(rand.NextDouble() * (2 * radius - radius) + radius);
                    if (IsValid(candidate, regionSize, cellSize, radius, points, grid))
                    {
                        points.Add(candidate);
                        spawnPoints.Add(candidate);
                        grid[(int)(candidate.x / cellSize), (int)(candidate.y / cellSize)] = points.Count;
                        candidateAccepted = true;
                        break;
                    }
                }
                if (!candidateAccepted)
                {
                    spawnPoints.RemoveAt(spawnIndex);
                }

            }

            return points;
        }

        private static bool IsValid(Vector2 point, Vector2 regionSize, float cellSize, float radius, List<Vector2> points, int[,] grid)
        {
            if (point.x >= 0 && point.x < regionSize.x && point.y >= 0 && point.y < regionSize.y)
            {
                int cellX = (int)(point.x / cellSize);
                int cellY = (int)(point.y / cellSize);
                int searchStartX = Mathf.Max(0, cellX - 2);
                int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0) - 1);
                int searchStartY = Mathf.Max(0, cellY - 2);
                int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1) - 1);

                for (int x = searchStartX; x <= searchEndX; x++)
                {
                    for (int y = searchStartY; y <= searchEndY; y++)
                    {
                        int pointIndex = grid[x, y] - 1;
                        if (pointIndex != -1)
                        {
                            float sqrDst = (point - points[pointIndex]).sqrMagnitude;
                            if (sqrDst < radius * radius)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generates a falloff map to turn any other noise map into an island rather than potential infinite terrain, <c>SLOW FUNCTION, GENERATE ONCE THEN USE</c>
        /// </summary>
        /// <param name="size">size, assumes square map, screw you if its not square, i aint gonna help you :)</param>
        /// <param name="a">changes how sharp the falloff is, higher = sharper</param>
        /// <param name="b">changes when the falloff begins, higher = later</param>
        /// <returns>float[,] that you can subtract from an existing float[,] heightmap</returns>
        public static float[,] GenerateFalloffMap(int size, float a, float b)
        {
            float[,] map = new float[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    float x = i / (float)size * 2 - 1;
                    float y = j / (float)size * 2 - 1;

                    float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                    value = Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
                    map[i, j] = value;
                }
            }

            return map;
        }
    }
}
