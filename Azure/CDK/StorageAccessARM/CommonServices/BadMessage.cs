﻿using System;

using Microsoft.Azure.Cosmos.Table;

#if CONSUMER
namespace MessageConsumer
#elif QUERY
namespace TableSearch.Services
#endif
{
    public class BadMessage : TableEntity
    {
        public string Text { get; set; }
    }
}
