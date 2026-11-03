namespace REST_API
{
    public interface IRecordsRepository
    {
        //Record AddRecord(Record record);
        //Record? DeleteRecord(int id);
        //Record? GetRecord(int id);
        List<Record> GetRecords(string? title, string? artist, int? publicationYear, int? minDuration, int? maxDuration);
        //Record? UpdateRecord(int id, Record record);
    }
}