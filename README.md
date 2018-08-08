# vs2017-unit-test-freeze-repro-307341

Repro for this VS issue: <https://developercommunity.visualstudio.com/content/problem/307341/visual-studio-freezing-100-cpu.html>

To repro the Visual Studio 2017 freezing follow these steps:

1. Open and build solution VisualStudioFreezingRepro\VisualStudioFreezingRepro.sln
2. Open Test Explorer window, run all unit tests
3. Expand list of tests, click on failed unit test "TestMethod1". Message similar to the following should be displayed:
    "Message: Test method VisualStudioFreezingRepro.UnitTest1.TestMethod1 threw exception:
    Shouldly.ShouldAssertException:
        bitmatRgbData
            should be
        []"

Result: Visual Studio is freezing and is barely responding once every 5 seconds, CPU usage of 1 core is 100%. To temporary fix this behavior, hide or close Test Exporer window.