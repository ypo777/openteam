// tasks/04‑sql‑reasoning/csharp/QueriesTests.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;
using Xunit;

namespace SqlReasoning.Tests
{
    public class QueriesTests
    {
        private static string RootDir => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        private static string DbPath   => Path.Combine(RootDir, "donations.db");
        private static string ExpDir   => Path.Combine(RootDir, "expected");

        // ---------- helpers ------------------------------------------------ //
        private static (string[] header, List<string[]> rows) Run(string sql)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            using var rdr = cmd.ExecuteReader();
            var header = new string[rdr.FieldCount];
            for (int i = 0; i < rdr.FieldCount; i++) header[i] = rdr.GetName(i);

            var rows = new List<string[]>();
            while (rdr.Read())
            {
                var row = new string[rdr.FieldCount];
                for (int i = 0; i < rdr.FieldCount; i++) row[i] = rdr.GetValue(i).ToString();
                rows.Add(row);
            }
            return (header, rows);
        }

        private static (string[] header, List<string[]> rows) LoadCsv(string name)
        {
            var path = Path.Combine(ExpDir, name);
            using var sr = new StreamReader(path);
            var header = sr.ReadLine()?.Split(',');
            var rows   = new List<string[]>();
            string? line;
            while ((line = sr.ReadLine()) != null)
                rows.Add(line.Split(','));
            return (header!, rows);
        }

        // ---------- tests -------------------------------------------------- //
        [Fact]
        public void TaskA_MatchesCsv()
        {
            var exp = LoadCsv("q1.csv");
            var got = Run(Queries.SQL_A);
            Assert.Equal(exp.header, got.header);
            Assert.Equal(exp.rows,   got.rows);
        }

        [Fact]
        public void TaskB_MatchesCsv()
        {
            var exp = LoadCsv("q2.csv");
            var got = Run(Queries.SQL_B);
            Assert.Equal(exp.header, got.header);
            Assert.Equal(exp.rows,   got.rows);
        }
    }
}
