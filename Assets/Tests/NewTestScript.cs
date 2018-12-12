
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewTestScript {

    GameObject player;
    GameObject pickup;


    [Test]
    public void NewTestScriptSimplePasses() {
        TestingScript testingScript = new TestingScript();
        Assert.AreEqual(20, testingScript.TestMethod(4));
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator PlayerPickupsOnCollision() {
        // Arrange
        Setup();

        // Act
        player.GetComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0));
        yield return new WaitForSeconds(2);

        // Assert
        PlayerController playerController = player.GetComponent<PlayerController>();
        Assert.AreEqual(1, playerController.count);

        Assert.AreEqual(false, pickup.activeSelf);
    }

    public void Setup()
    {
        // Adding camera so we can see things in real time
        Object.Instantiate(Resources.Load<GameObject>("Directional Light"));
        GameObject camera = Object.Instantiate(Resources.Load<GameObject>("Camera"));
        camera.GetComponent<CameraController>().player = player;

        Object.Instantiate(Resources.Load<GameObject>("Ground"));
        player = Object.Instantiate(Resources.Load<GameObject>("Player"));
        camera.GetComponent<CameraController>().player = player;

        pickup = Object.Instantiate(Resources.Load<GameObject>("PickUp"));
        Vector3 pos = new Vector3(2, 0, 0);
        pickup.transform.position += pos;
    }

}
