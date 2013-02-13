using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Convex_Hull_Examples.Models;

namespace Convex_Hull_Examples.Algorithms
{
    interface ConvexHullAlgorithm
    {
        List<Line> ComputeToStep(int step);

        int GetNumberOfSteps(List<Node> nodes);
    }
}
