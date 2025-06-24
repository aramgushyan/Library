using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Infastructure.Repository;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class LoadService
    {
        ILoadRepository _repository;
        public LoadService(ILoadRepository repository
            )
        {
            _repository = repository;
        }

        /// <summary>
        /// Создаёт Excel-файл,который состоит из таблиц с данными.
        /// </summary>
        /// <param name="path">Путь, по которому будет сохранён файл.</param>
        /// <param name="token">Токен отмены. </param>
        public void ExportTables(string path, CancellationToken token)
        { 

            var tables = _repository.GetTables();

            var excelWorkBook = new XLWorkbook();

            foreach (var table in tables) 
            {
                AddSheet(excelWorkBook,table, table.FirstOrDefault().GetType().Name);
            }
            

            excelWorkBook.SaveAs(path);
        }
        

        private void AddSheet<T>(XLWorkbook workBook, IEnumerable<T> table,string name) 
        {
            var sheet = workBook.Worksheets.Add(name);
            sheet.Cell(1, 1).InsertTable(table, false);
        }
    }
}
