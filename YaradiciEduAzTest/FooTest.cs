namespace YaradiciEduAzTest;

using YaradiciEduAz;

public class FooTest
{
    [Fact]
    public void PassingTest()
    {
        Assert.True(Foo.IsTrue());
    }

    [Fact]
    public void FailingTest()
    {
        Assert.False(Foo.IsTrue());
    }
}
