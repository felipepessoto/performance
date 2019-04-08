﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using BenchmarkDotNet.Attributes;

namespace System.MathBenchmarks
{
    public partial class Single
    {
        // Tests MathF.ILogB(float) over 5000 iterations for the domain +1, +3

        private const float iLogBDelta = 0.0004f;
        private const int iLogBExpectedResult = 2499;

        [Benchmark]
        public void ILogB() => ILogBTest();

        public static void ILogBTest()
        {
            var result = 0; var value = 1.0f;

            for (var iteration = 0; iteration < MathTests.Iterations; iteration++)
            {
                result += MathF.ILogB(value);
                value += iLogBDelta;
            }

            if (result != iLogBExpectedResult)
            {
                throw new Exception($"Expected Result {iLogBExpectedResult,10:g9}; Actual Result {result,10:g9}");
            }
        }
    }
}