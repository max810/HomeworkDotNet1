﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    [Obsolete]
    public interface IBinaryStory
    {
        IScene CurrentScene { get; }
    }
}
