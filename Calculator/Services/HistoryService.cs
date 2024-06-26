﻿using Calculator.Backend.Data;
using Calculator.Backend.Data.Extensions;
using Calculator.Backend.Data.Models.DTO;
using Calculator.Backend.Data.Models.Entities;
using Calculator.Backend.Data.Models.ServiceModels.History;
using Calculator.Backend.Services.Interfaces;

namespace Calculator.Backend.Services
{
    public class HistoryService : IHistoryService
    {

        public CalculatorDataContext DbContext { get; set; }
        public ILogger<HistoryService> Logger { get; set; }

        public HistoryService(CalculatorDataContext dbContext, ILogger<HistoryService> logger)
        {
            DbContext = dbContext;
            Logger = logger;
        }

        public bool Add(AddHistoryServiceModel addHistoryServiceModel)
        {
            string operationAlias = addHistoryServiceModel.OperationType.ToString();

            if (!DbContext.Database.CanConnect())
            {
                string logMessage = $"Can't connect to database";
                Logger.LogWarning(logMessage);
                return false;
            }

            var operation = DbContext.Operations
                .ToList()
                .FirstOrDefault(o => o.Alias.IsEqualsIgnoreCase(operationAlias));
            if (operation is null)
            {
                string logMessage = $"Operation '{operationAlias}' not found. Can't Add data to History table";
                Logger.LogError(logMessage);
                return false;
            }

            var history = new History
            {
                Param1 = addHistoryServiceModel.Param1,
                Param2 = addHistoryServiceModel.Param2,
                Result = addHistoryServiceModel.Result,
                OperationId = operation.Id
            };

            DbContext.Histories.Add(history);
            DbContext.SaveChanges();
            return true;
        }

        public List<HistoryDTO>? GetAll()
        {
            if (!DbContext.Database.CanConnect())
            {
                string logMessage = $"Can't connect to database";
                Logger.LogWarning(logMessage);
                return null;
            }

            var historiesDTO = new List<HistoryDTO>();
            historiesDTO = DbContext.Histories.Join(
                DbContext.Operations,
                h => h.OperationId,
                o => o.Id,
                (h, o) => new HistoryDTO
                {
                    Param1 = h.Param1,
                    Param2 = h.Param2,
                    Result = h.Result,
                    OperationName = o.Name
                })
                .ToList();

            return historiesDTO;
        }
    }
}
