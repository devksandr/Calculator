﻿using Calculator.Backend.Data.Entities;
using Calculator.Backend.Data.Enums;

namespace Calculator.Backend.Data.ServiceModels.History
{
    public class AddHistoryServiceModel
    {
        public float Param1 { get; set; }
        public float Param2 { get; set; }
        public float Result { get; set; }
        public OperationType OperationType { get; set; }
    }
}
