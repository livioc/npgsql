﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Relational.Query;
using Microsoft.Data.Entity.Relational.Query.Methods;
using Microsoft.Framework.Logging;
using Npgsql.EntityFramework7.Query.Methods;

namespace Npgsql.EntityFramework7
{
    public class NpgsqlCompositeMethodCallTranslator : RelationalCompositeMethodCallTranslator
    {
        private readonly List<IMethodCallTranslator> _npgsqlTranslators = new List<IMethodCallTranslator>
        {
            new StringSubstringTranslator(),
            new MathAbsTranslator(),
            new MathCeilingTranslator(),
            new MathFloorTranslator(),
            new MathPowerTranslator(),
            new MathRoundTranslator(),
            new MathTruncateTranslator(),
            new StringReplaceTranslator(),
            new StringToLowerTranslator(),
            new StringToUpperTranslator()
        };

        public NpgsqlCompositeMethodCallTranslator([NotNull] ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
        }

        protected override IReadOnlyList<IMethodCallTranslator> Translators
            => base.Translators.Concat(_npgsqlTranslators).ToList();
    }
}