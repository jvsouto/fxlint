﻿using System;
using CommandLine;

namespace fxlint
{
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<FixOptions, ScannerOptions, ListOptions>(args)
                .MapResult(
                    (FixOptions opts) => new Fixer().StartAsync(opts).Result,
                    (ScannerOptions opts) => new Scanner().StartAsync(opts).Result,
                    (ListOptions opts) => new List().StartAsync(opts).Result,
                    errs => 1);
        }
    }
}
