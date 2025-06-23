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
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IBookLendingService _bookLendingService;
        private readonly IBookService _bookService;
        private readonly IEmployeeService _employeeService;
        private readonly IGenreService _genreService;
        private readonly IInstanceService _instanceService;
        private readonly ILibraryService _libraryService;
        private readonly IReaderService _readerService;

        public LoadService(
            IAccountService accountService,
            IAuthorService authorService,
            IAuthorBookService authorBookService,
            IBookGenreService bookGenreService,
            IBookLendingService bookLendingService,
            IBookService bookService,
            IEmployeeService employeeService,
            IGenreService genreService,
            IInstanceService instanceService,
            ILibraryService libraryService,
            IReaderService readerService
        )
        {
            _authorService = authorService;
            _authorBookService = authorBookService;
            _bookGenreService = bookGenreService;
            _bookLendingService = bookLendingService;
            _bookService = bookService;
            _employeeService = employeeService;
            _genreService = genreService;
            _instanceService = instanceService;
            _libraryService = libraryService;
            _readerService = readerService;
        }


        public async Task ExportTablesAsync(string path, CancellationToken token) 
        {
            var authors = await _authorService.GetAllAsync(token);
            var books = await _bookService.GetAllAsync(token);
            var genres = await _genreService.GetAllAsync(token);
            var authorBooks = await _authorBookService.GetAllAsync(token);
            var bookGenres = await _bookGenreService.GetAllAsync(token);
            var bookLendings = await _bookLendingService.GetAllAsync(token);
            var employees = await _employeeService.GetAllAsync(token);
            var instances = await _instanceService.GetAllAsync(token);
            var libraries = await _libraryService.GetAllAsync(token);
            var readers = await _readerService.GetAllAsync(token);

            var excelWorkBook = new XLWorkbook();

            AddSheet(excelWorkBook, authors, "Authors");
            AddSheet(excelWorkBook, books, "Books");
            AddSheet(excelWorkBook, genres, "Genres");
            AddSheet(excelWorkBook, authorBooks, "AuthorBooks");
            AddSheet(excelWorkBook, bookGenres, "BookGenres");
            AddSheet(excelWorkBook, bookLendings, "BookLendings");
            AddSheet(excelWorkBook, employees, "Employees");
            AddSheet(excelWorkBook, instances, "Instances");
            AddSheet(excelWorkBook, libraries, "Libraries");
            AddSheet(excelWorkBook, readers, "Readers");

            excelWorkBook.SaveAs(path);
        }
        

        private void AddSheet<T>(XLWorkbook workBook, IEnumerable<T> table,string name) 
        {
            var sheet = workBook.Worksheets.Add(name);
            sheet.Cell(1, 1).InsertTable(table, false);
        }
    }
}
