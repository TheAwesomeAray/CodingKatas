using System.Collections.Generic;
using System.Linq;


public class Sudoku
{
    private int[][] puzzle;
    private int puzzleSize => puzzle.Length;

    public Sudoku(int[][] puzzle)
    {
        this.puzzle = puzzle;
    }

    public bool IsValid()
    {
        if (!ValidPuzzleSize(puzzle))
            return false;

        return ValidPuzzleContents(puzzle);
    }

    private bool ValidPuzzleContents(int[][] puzzle)
    {
        foreach (var arr in puzzle)
        {
            if (!XAxisContainsCorrectValues(arr))
                return false;
        }

        return ContainsDuplicatesOnYAxis();
    }

    private bool ContainsDuplicatesOnYAxis()
    {
        for (int i = 0; i < puzzleSize; i++)
        {
            var arr = new int[puzzleSize];

            for (int j = 0; j < puzzleSize; j++)
            {
                arr[j] = puzzle[j][i];
            }

            for (int x = 1; x <= arr.Length; x++)
            {
                if (!arr.Contains(x))
                    return false;
            }
        }

        return true;
    }

    private bool XAxisContainsCorrectValues(int[] arr)
    {
        for (int i = 1; i <= arr.Length; i++)
        {
            if (!arr.Contains(i))
                return false;
        }

        return true;
    }

    public bool ValidPuzzleSize(int[][] puzzle)
    {
        if (!puzzle.Any())
            return false;

        foreach (var arr in puzzle)
        {
            if (arr.Length != puzzleSize)
                return false;
        }

        return true;
    }
}

