using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;
using UnityEngine.SceneManagement;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    AndroidNotificationChannel notifChannel;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Reminder to Login",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        DisplayNotification("volve a jugar!!!", "te necesitamos",
            IconSelecter.icon_0, 
            DateTime.UtcNow.AddMinutes(2));
        Debug.Log($"Notificación programada con ID: {notifChannel}");

        DisplayNotification2("Salio el nivel 2!", "probalo entrando en esta notificacion",
            IconSelecter.icon_0,
            DateTime.UtcNow.AddMinutes(1));
            CheckNotificationIntent();
        Debug.Log($"Notificación 2 programada con ID: {notifChannel}");

        
    }

    public int DisplayNotification(string title, string text, IconSelecter iconSmall, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.SmallIcon = iconSmall.ToString();
        notification.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }

    //NOTIFICACION DE NUEVO NIVEL
    public int DisplayNotification2(string title, string text, IconSelecter iconSmall, DateTime fireTime)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            SmallIcon = iconSmall.ToString(),
            FireTime = fireTime,
            IntentData = "LoadLevel2"
            
        };

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }
    public void CancelNotification (int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
    public enum IconSelecter
    {
        icon_0,
        
    }
    private void CheckNotificationIntent()
    {

        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

        if (notificationIntentData != null && notificationIntentData.Notification.IntentData == "LoadLevel2")
        {
            Debug.Log("Notificación detectada: Cargando Nivel 2");

            SceneManager.LoadScene("NivelDos");
        }
    }
}

