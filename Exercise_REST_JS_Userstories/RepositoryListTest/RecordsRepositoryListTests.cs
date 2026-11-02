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
    [Fact]
    public void TestAddRecordNull()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList();
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => repository.AddRecord(null!));
    }
    [Fact]
    public void TestGetRecord()
    {
        //Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        // Act
        Record? existingRecord = repository.GetRecord(1);
        // Assert
        Assert.NotNull(existingRecord);
        Assert.Equal(1, existingRecord!.Id);
    } 
    [Fact]
    public void TestGetRecordNonExisting()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        // Act
        Record? nonExistingRecord = repository.GetRecord(-1);
        // Assert
        Assert.Null(nonExistingRecord);
    }
    [Fact]
    public void TestUpdateRecord()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        Record updatedRecord = new Record { Title = "Updated Title", Artist = "Updated Artist", Duration = 250, PublicationYear = 2025 };
        // Act
        Record? result = repository.UpdateRecord(1, updatedRecord);
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Title", result!.Title);
        Assert.Equal("Updated Artist", result.Artist);
    }
    [Fact]
    public void TestUpdateRecordNull()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => repository.UpdateRecord(1, null!));
    }
    [Fact]
    public void TestUpdateRecordNonExisting()
    {
        //Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        Record updatedRecord = new Record { Title = "Updated Title", Artist = "Updated Artist", Duration = 250, PublicationYear = 2025 };
        // Act
        Record? result = repository.UpdateRecord(-1, updatedRecord);
        // Assert
        Assert.Null(result);
    }
    [Fact]  
    public void TestDeleteRecord()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        // Act
        Record? deletedRecord = repository.DeleteRecord(1);
        // Assert
        Assert.NotNull(deletedRecord);
        Assert.Null(repository.GetRecord(1));
    }
    [Fact]
    public void TestDeleteRecordNonExisting()
    {
        // Arrange
        RecordsRepositoryList repository = new RecordsRepositoryList(initializeWithSampleData: true);
        // Act
        Record? deletedRecord = repository.DeleteRecord(-1);
        // Assert
        Assert.Null(deletedRecord);
    }
}
