using REST_API;
using Record = REST_API.Record;

namespace RepositoryListTest;

public class RecordsRepositoryListTests
{
    [Fact]
    public void TestGetAllRecords()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);

        // Act
        List<Record> fetchedRecords = repository.GetRecords();

        // Assert
        Assert.NotNull(fetchedRecords);
        Assert.Equal(4, fetchedRecords.Count);
    }
    [Fact]
    public void TestGetAllRecordsEmpty()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList();
        // Act
        List<Record> fetchedRecords = repository.GetRecords();
        // Assert
        Assert.NotNull(fetchedRecords);
        Assert.Empty(fetchedRecords);
    }
    [Fact]
    public void TestGetAllRecordsShallowCopy()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        List<Record> shallowCopy = repository.GetRecords();
        // Act
        shallowCopy.Clear();
        List<Record> secondCopy = repository.GetRecords();
        // Arrange
        Assert.NotNull(secondCopy);
        Assert.Equal(4, secondCopy.Count);
    }
    [Fact]
    public void TestAddRecord()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList();
        int beforeCount = repository.Count;
        Record newRecord = new Record { Title = "New Record", Artist = "New Artist", Duration = 300, PublicationYear = 2024 };
        // Act
        Record addedRecord = repository.AddRecord(newRecord);
        int afterCount = repository.Count;
        List<Record> fetchedRecords = repository.GetRecords();
        // Assert
        Assert.NotNull(addedRecord);
        Assert.Single(fetchedRecords);
        Assert.Equal("New Record", fetchedRecords[0].Title);
        Assert.Equal(beforeCount + 1, afterCount);
    }
}
