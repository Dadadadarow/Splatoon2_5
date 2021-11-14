using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
public class SerialHandlerIn : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    // public string portName = "COM8";
    public string portName = "COM8";
    public int baudRate = 115200;
    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;
    private string message_;
    private bool isNewMassageReceived_ = false;
    void Awake()
    {
        Open();
    }
    // Update is called once per frame
    void Update()
    {
        if (isNewMassageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMassageReceived_ = false;
    }
    
    void OnDestroy()
    {
        Close();
    }
    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();
        isRunning_ = true;
        thread_ = new Thread(Read);
        thread_.Start();
    }
    private void Close()
    {
        isRunning_ = false;
        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
        }
        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }
    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
            try
            {
                message_ = serialPort_.ReadLine();
                isNewMassageReceived_ = true;
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort_.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}

// test