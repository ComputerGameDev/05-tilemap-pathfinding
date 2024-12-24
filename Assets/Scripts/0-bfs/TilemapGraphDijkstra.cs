using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A graph that represents a tilemap, using only the allowed tiles.
 */
public class TilemapGraphDijkstra: IGraph<Vector3Int> {
    private Tilemap tilemap;
    private TileBase[] allowedTiles;
    Dictionary<string, int> tileWeights = new Dictionary<string, int>()
    {
        {"Grass", 1},
        {"Swamp", 2},
        {"bushes", 3},
        {"Hills", 4},
    };


    public TilemapGraphDijkstra(Tilemap tilemap, TileBase[] allowedTiles) {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
    }

    static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
    };

    public IEnumerable<Vector3Int> Neighbors(Vector3Int node) {
        foreach (var direction in directions) {
            Vector3Int neighborPos = node + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            if (allowedTiles.Contains(neighborTile))
                yield return neighborPos;
        }
    }

        public int GetWeight(Vector3Int node) {
        TileBase tile = tilemap.GetTile(node);
        if (tile != null) {
            string tileName = tile.name;
            if (tileWeights.ContainsKey(tileName)) {
                return tileWeights[tileName];
            }
        }
        return int.MaxValue;
    }
}

