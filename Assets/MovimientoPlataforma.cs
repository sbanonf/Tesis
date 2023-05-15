using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DireccionH { Izquierda, Derecha }
public enum DireccionV { Arriba, Abajo }

public class MovimientoPlataforma : MonoBehaviour
{
    // Es la velocidad a la que se mover� la plataforma en el eje horizontal.
    public float VelocidadH = 0.3F;

    // Indica el sentido horizontal al que comenzar� a moverse la plataforma.
    public DireccionH SentidoH = DireccionH.Derecha;

    // Es la velocidad a la que se mover� la plataforma en el eje vertical.
    public float VelocidadV = 0.0F;

    // Indica el sentido vertical al que comenzar� a moverse la plataforma.
    public DireccionV SentidoV = DireccionV.Arriba;

    // Es el la distancia que recorrer� la plataforma en modo ping-pong.
    // Para desactivar el modo ping-pong, establecer esta variable a -1.
    public float MaxRecorridoPingPong = 5.0F;

    // Variables privadas
    private Transform PlatformTransform;
    private float WalkedDistanceH = 0.0F;
    private float WalkedDistanceV = 0.0F;
    private float ReferencePingPongHPosition;
    private float ReferencePingPongVPosition;
    private Vector3 InitialPlatformPosition;

    void Start()
    {
        PlatformTransform = transform;

        // Guardamos la posici�n inicial de la plataforma
        InitialPlatformPosition = PlatformTransform.position;

        // Inicializamos la posici�n de referencia para el c�lculo de rebote horizontal (ping-pong)
        ReferencePingPongHPosition = PlatformTransform.position.x;

        // Inicializamos la posici�n de referencia para el c�lculo de rebote vertical (ping-pong)
        ReferencePingPongVPosition = PlatformTransform.position.y;
    }
    void Update()
    {
        // Calculamos la distancia horizontal recorrida desde el �ltimo rebote
        WalkedDistanceH = Math.Abs(PlatformTransform.position.x - ReferencePingPongHPosition);

        // Calculamos la distancia vertical recorrida desde el �ltimo rebote
        WalkedDistanceV = Math.Abs(PlatformTransform.position.y - ReferencePingPongVPosition);

        if (MaxRecorridoPingPong != -1 && WalkedDistanceH >= MaxRecorridoPingPong)
        {
            // Si la funci�n de Ping-Pong esta activada y se ha hecho el m�ximo recorrido en horizontal, la plataforma cambia de sentido
            if (SentidoH == DireccionH.Izquierda)
            {
                SentidoH = DireccionH.Derecha;
            }
            else
            {
                SentidoH = DireccionH.Izquierda;
            }

            // Actualizamos la posici�n horizontal de referencia para el c�lculo de rebote horizontal (ping-pong)
            ReferencePingPongHPosition = PlatformTransform.position.x;
        }

        if (MaxRecorridoPingPong != -1 && WalkedDistanceV >= MaxRecorridoPingPong)
        {
            // Si la funci�n de Ping-Pong est� activada y se ha hecho el m�ximo recorrido en vertical, la plataforma cambia de sentido
            if (SentidoV == DireccionV.Arriba)
            {
                SentidoV = DireccionV.Abajo;
            }
            else
            {
                SentidoV = DireccionV.Arriba;
            }

            // Actualizamos la posicion vertical de referencia para el calculo de rebote vertical (ping-pong)
            ReferencePingPongVPosition = PlatformTransform.position.y;
        }

        // Configuramos el sentido del movimiento horizontal
        if (SentidoH == DireccionH.Izquierda)
        {
            VelocidadH = -Math.Abs(VelocidadH);
        }
        else
        {
            VelocidadH = Math.Abs(VelocidadH);
        }

        // Configuramos el sentido del movimiento vertical
        if (SentidoV == DireccionV.Abajo)
        {
            VelocidadV = -Math.Abs(VelocidadV);
        }
        else
        {
            VelocidadV = Math.Abs(VelocidadV);
        }

        // Movemos la plataforma
        PlatformTransform.Translate(new Vector3(VelocidadH, VelocidadV, 0) * Time.deltaTime);
    }
    void OnTriggerStay(Collider other)
    {
        // Inclu�mos como hijo de la plataforma a cualquier objeto que se pose sobre ella
        other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        // Exclu�mos como hijo de la plataforma a cualquier objeto que se separe de ella
        other.transform.parent = null;
    }
}

