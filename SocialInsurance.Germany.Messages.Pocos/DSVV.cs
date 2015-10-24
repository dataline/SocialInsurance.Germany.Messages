﻿// <copyright file="DSVV.cs" company="DATALINE GmbH &amp; Co. KG">
// Copyright (c) DATALINE GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace SocialInsurance.Germany.Messages.Pocos
{
    /// <summary>
    /// Datensatz: DSVV - Vergabe einer Versicherungs-/Verfahrensnummer
    /// </summary>
    public class DSVV : IDatensatz
    {
        private FehlerKennzeichen? _fekz;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="DSVV"/> Klasse
        /// </summary>
        /// <remarks>
        /// Beim Initialisieren werden die Konstanten, wie Kennung und Verfahren gesetzt
        /// </remarks>
        public DSVV()
        {
            KE = "DSVV";
            VF = "ELENA";
            VERNR = 1;
        }

        /// <summary>
        /// Holt oder setzt die Kennung
        /// </summary>
        /// <remarks>
        /// Kennung, um welchen Datensatz es sich handelt
        /// </remarks>
        public string KE { get; set; }

        /// <summary>
        /// Holt oder setzt das Verfahren
        /// </summary>
        /// <remarks>
        /// Verfahren, für das der Datensatz bestimmt ist, Länge 5,  Mussangabe
        /// BVBEI = BV Beitragserhebung
        /// </remarks>
        public string VF { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Erstellers des Datensatzes
        /// </summary>
        /// <remarks>
        /// Betriebsnummer des Erstellers des Datensatzes, Länge 8, Mussangabe
        /// </remarks>
        public string BBNRAB { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Empfängers des Datensatzes
        /// </summary>
        /// <remarks>
        /// Betriebsnummer des Empfängers des Datensatzes, Länge 8, Mussangabe
        /// </remarks>
        public string BBNREP { get; set; }

        /// <summary>
        /// Holt oder setzt die Versionsnummer des übermittelten Datensatzes
        /// </summary>
        /// <remarks>
        /// Versionsnummer des Datensatzes, Länge 2, Mussangabe
        /// 01 – 99
        /// </remarks>
        public int VERNR { get; set; }

        /// <summary>
        /// Holt oder setzt den Zeitpunkt der Erstellung des Datensatzes
        /// </summary>
        /// <remarks>
        /// Zeitpunkt der Erstellung des Datensatzes, Länge 20, Mussangabe
        /// </remarks>
        public DateTime ED { get; set; }

        /// <summary>
        /// Holt oder setzt die Kennzeichnung für fehlerhafte Datensätze
        /// </summary>
        /// <remarks>
        /// Kennzeichnung für fehlerhafte Datensätze, Länge 1, 0 = Datensatz fehlerfrei 1 = Datensatz fehlerhaft, Mussangabe
        /// </remarks>
        public FehlerKennzeichen FEKZ
        {
            get { return _fekz ?? (DBFE == null || DBFE.Count == 0 ? FehlerKennzeichen.Fehlerfrei : FehlerKennzeichen.Fehlerhaft); }
            set { _fekz = value; }
        }

        /// <summary>
        /// Holt die Anzahl der Fehler des Datensatzes
        /// </summary>
        /// <remarks>
        /// Anzahl der Fehler des Datensatzes, Länge 1, Mussangabe
        /// </remarks>
        public int FEAN
        {
            get { return DBFE == null ? 0 : DBFE.Count; }
            private set { }
        }

        /// <summary>
        /// Holt oder setzt die Versicherungsnummer/Verfahrensnummer
        /// </summary>
        /// <remarks>
        /// Ist bei der Anforderung leer, Länge 12
        /// </remarks>
        public string VSNRVFNR { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Verursachers des Datensatzes
        /// </summary>
        /// <remarks>
        /// Betriebsnummer des Verursachers des Datensatzes, Länge 15, Mussangabe
        /// Bei Meldungen zwischen dem Arbeitgeber und der ZSS ist hier
        /// die Betriebsnummer des Beschäftigungsbetriebes anzugeben
        /// </remarks>
        public string BBNRVU { get; set; }

        /// <summary>
        /// Holt oder setzt das dem Verursacher zur Verfügung stehende Feld
        /// </summary>
        /// <remarks>
        /// Dieses Feld steht dem Verursacher zur Verfügung, Länge 20, Kannangabe
        /// Bei Meldungen zwischen dem Arbeitgeber und der ZSS: z. B. Aktenzeichen/Personalnummer des/der Beschäftigten
        /// </remarks>
        public string AZVU { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer der für den/die Beschäftigte(n) zuständigen Krankenkasse
        /// </summary>
        /// <remarks>
        /// Betriebsnummer der für den/die Beschäftigte(n) zuständigen Krankenkasse, Länge 15, Mussangabe unter Bedingungen
        /// </remarks>
        public string BBNRKK { get; set; }

        /// <summary>
        /// Holt oder setzt das Aktenzeichen KK
        /// </summary>
        /// <remarks>
        /// Entfällt hier, Grundstellung liefern, Länge 20, Mussangabe
        /// </remarks>
        public string AZKK { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer der Abrechnungsstelle
        /// </summary>
        /// <remarks>
        /// Betriebsnummer der Abrechnungsstelle (z.B. Steuerberater), Länge 15, Pflichtangabe, soweit bekannt
        /// </remarks>
        public string BBNRAS { get; set; }

        /// <summary>
        /// Holt oder setzt die Personengruppe
        /// </summary>
        /// <remarks>
        /// Personengruppe gemäß Anlage 3 der Gemeinsamen Grundsätze, Länge 3, Mussangabe
        /// für die Datenerfassung und Datenübermittlung zur Sozialversicherung nach § 28b Abs. 2 SGB IV
        /// </remarks>
        public int PERSGR { get; set; }

        /// <summary>
        /// Holt oder setzt den Abgabegrund
        /// </summary>
        /// <remarks>
        /// Entfällt hier, Grundstellung liefern, Länge 2, Mussangabe
        /// </remarks>
        public int GD { get; set; }

        /// <summary>
        /// Holt oder setzt den Staatsangehörigkeitsschlüssel
        /// </summary>
        /// <remarks>
        /// Staatsangehörigkeitsschlüssel des statistischen Bundesamtes, Länge 3, Mussangabe
        /// </remarks>
        public string SASC { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob die Person als Beamter/Soldat/Richter tätig ist
        /// </summary>
        /// <remarks>
        /// Ist diese Person als Beamter / Richter / Soldat tätig? Länge 1, Mussangabe
        /// J = j, N = nein
        /// </remarks>
        public bool BEAM { get; set; }

        /// <summary>
        /// Holt oder setzt das Anfangsdatum des Zeitraumes innerhalb des Meldemonats, der durch diese Meldung abgedeckt wird
        /// </summary>
        /// <remarks>
        /// Entfällt hier, Grundstellung liefern, Länge 8, Mussangabe
        /// </remarks>
        public string MONATBEG { get; set; }

        /// <summary>
        /// Holt oder setzt das Enddatum des Zeitraumes innerhalb des Meldemonats, der durch diese Meldung abgedeckt wird
        /// </summary>
        /// <remarks>
        /// Entfällt hier, Grundstellung liefern, Länge 2, Mussangabe
        /// </remarks>
        public string MONATEND { get; set; }

        /// <summary>
        /// Holt oder setzt die abweichende Betriebsnummer des Unternehmens
        /// </summary>
        /// <remarks>
        /// Entfällt hier, Grundstellung liefern, Länge 15, Mussangabe
        /// </remarks>
        public string BBNRALT { get; set; }

        /// <summary>
        /// Holt oder setzt das dem Verursacher zur Verfügung stehende Feld
        /// </summary>
        /// <remarks>
        /// Dieses Feld steht dem Verursacher zur Verfügung, Länge 20, Kannangabe
        /// Bei Meldungen zwischen dem Arbeitgeber und der ZSS: z. B. Aktenzeichen/Personalnummer des / der Beschäftigten
        /// </remarks>
        public string DSID { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob es sich um eine Stornierung handelt
        /// </summary>
        /// <remarks>
        /// Kennzeichen, Stornierung einer bereits abgegebenen Meldung
        /// N = keine Stornierung
        /// </remarks>
        public bool KENNZST { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein ELENA Grunddaten vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBEN, Länge 1, Mussangabe
        /// N = keine Grunddaten
        /// </remarks>
        public bool MMEN { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Name vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBNA, Länge 1, Mussangabe
        /// J = Namensdaten vorhanden
        /// </remarks>
        public bool MMNA { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Geburtsangaben vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBGB, Länge 1, Mussangabe
        /// J = Geburtsangaben vorhanden
        /// </remarks>
        public bool MMGB { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Anschrift vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAN, Länge 1,
        /// J = Anschriftsangaben vorhanden
        /// </remarks>
        public bool MMAN { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Arbeitgeberangaben vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAG, Länge 1, Mussangabe
        /// N = keine Arbeitgeberangaben
        /// </remarks>
        public bool MMAG { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Arbeitgeberanschrift abweichender Beschäftigungsort vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAB
        /// N = kein abweichender Beschäftigungsort
        /// </remarks>
        public bool MMAB { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Fehlzeiten vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBFZ, Länge 1, Mussangabe
        /// N = keine Fehlzeiten
        /// </remarks>
        public bool MMFZ { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Steuerpflichtiger sonstiger Bezug vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBSE, Länge 1, Mussangabe
        /// N = keine Beträge
        /// </remarks>
        public bool MMSE { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Steuerfreie Bezüge vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBSB, Länge 1, Mussangabe
        /// N = keine Beträge
        /// </remarks>
        public bool MMSB { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Ausbildung vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAS, Länge 1, Mussangabe
        /// N = keine DBAS-Daten
        /// </remarks>
        public bool MMAS { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Zusatzdaten vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBZD, Länge 1, Mussangabe
        /// N = keine Zusatzdaten
        /// </remarks>
        public bool MMZD { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Nebenbeschäftigung Arbeitslose vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBNB, Länge 1, Mussangabe
        /// N = keine DBNB-Daten
        /// </remarks>
        public bool MMNB { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Heimatarbeiter vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBHA, Länge 1, Mussangabe
        /// N = keine DBHA-Daten
        /// </remarks>
        public bool MMHA { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Kündigung/Entlassung vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBKE, Länge 1, Mussangabe
        /// N = keine DBKE-Daten
        /// </remarks>
        public bool MMKE { get; set; }

        /// <summary>
        /// Holt oder setzt eine Liste von Fehlern
        /// </summary>
        public IList<DBFE> DBFE { get; set; }

        private IList<DBNA> ListeDBNA { get; set; }

        private IList<DBGB> ListeDBGB { get; set; }

        private IList<DBAN> ListeDBAN { get; set; }
    }
}
