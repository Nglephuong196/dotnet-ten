// See https://aka.ms/new-console-template for more information
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.S3;

Console.WriteLine("Hello, World!");


var s3Client = new AmazonS3Client(RegionEndpoint.APSoutheast1);
var ec2Client = new AmazonEC2Client(RegionEndpoint.APSoutheast1);

await ListBucketsExample(s3Client);

await GeListEC2(ec2Client);

static async Task ListBucketsExample(IAmazonS3 s3Client)
{
    var response = await s3Client.ListBucketsAsync();

    Console.WriteLine("My S3 Buckets:");
    foreach (var bucket in response.Buckets)
    {
        Console.WriteLine($"  - {bucket.BucketName} (Created: {bucket.CreationDate})");
    }
}

static async Task GeListEC2(IAmazonEC2 ec2Client)
{
    var request = new DescribeInstancesRequest();
    var response = await ec2Client.DescribeInstancesAsync(request);

    var instances = new List<EC2InstanceInfo>();

    foreach (var reservation in response.Reservations)
    {
        foreach (var instance in reservation.Instances)
        {
            var instanceInfo = new EC2InstanceInfo
            {
                Name = instance.Tags.FirstOrDefault(t => t.Key == "Name")?.Value,
                InstanceId = instance.InstanceId,
            };
            instances.Add(instanceInfo);
        }
    }

    foreach (var instance in instances)
    {
        Console.WriteLine($"  - {instance.Name} (Created: {instance.InstanceId})");
    }
}

public class EC2InstanceInfo
{
    public string Name { get; set; }
    public string InstanceId { get; set; }
}