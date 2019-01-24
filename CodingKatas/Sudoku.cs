using System;
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
        if (!ValidPuzzleSize())
            return false;

        if (!ValidLittleSqaures())
            return false;



        return ValidPuzzleContents();
    }

    private bool ValidLittleSqaures()
    {
        var littleSquareSize = Math.Sqrt(puzzleSize);

        for (int i = 0; i < puzzleSize / littleSquareSize; i++)
        {
            var littleSquare = new HashSet<int>();

            for (int j = 0; j < littleSquareSize; j++)
            {
                for (int k = 0; k < littleSquareSize; k++)
                {
                    littleSquare.Add(puzzle[j][k]);
                }
            }

            if (littleSquare.Count != puzzleSize)
                return false;
        }

        return true;
    }

    private bool ValidPuzzleContents()
    {
        foreach (var arr in puzzle)
        {
            if (!XAxisContainsCorrectValues(arr))
                return false;
        }

        return YAxisContainsCorrectValues();
    }

    private bool YAxisContainsCorrectValues()
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

    public bool ValidPuzzleSize()
    {
        if (!puzzle.Any())
            return false;

        if (Math.Sqrt(puzzleSize) % 1 != 0)
            return false;

        foreach (var arr in puzzle)
        {
            if (arr.Length != puzzleSize)
                return false;
        }

        return true;
    }
}

