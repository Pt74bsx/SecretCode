<div align="center">

# 🔐 SecretCode

### Jeu de logique en console développé en C#

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Status](https://img.shields.io/badge/statut-projet%20scolaire-blue?style=for-the-badge)

</div>

## 📖 Présentation

**SecretCode** est un jeu en ligne de commande dans lequel le joueur doit retrouver un code secret composé de quatre chiffres. Le programme génère le code, analyse chaque proposition et accompagne le joueur jusqu'à la victoire ou l'épuisement du nombre d'essais.

Ce projet a été réalisé à l'ETML afin de mettre en pratique les bases de la programmation en C# : conditions, boucles, tableaux, validation des saisies, génération aléatoire et organisation d'un programme complet.

## ✨ Fonctionnalités

- génération automatique d'un code secret de quatre chiffres ;
- quatre niveaux de difficulté ;
- limitation à dix tentatives par partie ;
- contrôle et validation des saisies utilisateur ;
- indices permettant d'affiner les propositions ;
- affichage adapté à une utilisation en console ;
- possibilité de recommencer une partie ;
- mode administrateur destiné au contrôle et au débogage ;
- temporisations et retours visuels pour rendre l'expérience plus lisible.

## 🎚️ Niveaux de difficulté

Les niveaux font varier les chiffres pouvant apparaître dans le code et les règles appliquées :

| Niveau | Principe |
|---|---|
| 1 | Découverte du jeu avec une plage de chiffres réduite |
| 2 | Difficulté intermédiaire |
| 3 | Plage de valeurs étendue |
| 4 | Difficulté maximale avec des chiffres allant jusqu'à 9 |

Le code possède une longueur fixe de quatre chiffres et le joueur dispose au maximum de dix essais.

## 🛠️ Technologies

- **C#**
- **.NET / application console**
- **Visual Studio**
- bibliothèques standard : `System`, `Collections.Generic`, `Linq`, `Threading` et `Tasks`

## 🗂️ Structure du dépôt

```text
SecretCode/
├── secretcode/
│   ├── Program.cs
│   ├── App.config
│   ├── secretcode_pt74bsx.csproj
│   └── secretcode_pt74bsx.sln
├── support/
│   ├── consigne du projet
│   ├── journal de travail
│   └── exécutable d'exemple
└── README.md
```

Le fonctionnement principal se trouve dans `Program.cs`. Le dossier `support` regroupe les documents fournis ou produits pendant le projet.

## 🚀 Installation et lancement

### Prérequis

- Windows ;
- Visual Studio avec la charge de travail .NET ;
- Git, facultatif si le dépôt est téléchargé en archive ZIP.

### Depuis Visual Studio

1. Clone le dépôt :

   ```bash
   git clone https://github.com/Pt74bsx/SecretCode.git
   ```

2. Ouvre `secretcode/secretcode_pt74bsx.sln`.
3. Laisse Visual Studio restaurer et charger le projet.
4. Sélectionne une configuration de compilation.
5. Lance le programme avec **F5** ou **Ctrl+F5**.

## 🎮 Utilisation

1. Choisis un niveau de difficulté dans le menu.
2. Saisis une proposition de quatre chiffres.
3. Observe les indications retournées par le programme.
4. Ajuste ta proposition jusqu'à trouver le code.
5. À la fin de la partie, choisis de recommencer ou de quitter.

## 🧠 Compétences travaillées

- décomposition d'un problème en étapes ;
- validation robuste des entrées ;
- manipulation de nombres et de chaînes ;
- génération pseudo-aléatoire ;
- gestion d'états et de menus ;
- conventions de nommage et documentation du code ;
- amélioration progressive d'une expérience utilisateur en console.

## ⚠️ Limites actuelles

- l'application est conçue pour une longueur fixe de quatre chiffres ;
- l'interface reste entièrement textuelle ;
- les paramètres de jeu sont principalement définis dans le code ;
- aucun système de sauvegarde des scores n'est encore inclus.

## 🔭 Améliorations possibles

- rendre la longueur du code configurable ;
- ajouter un classement persistant ;
- séparer la logique métier de l'interface console ;
- ajouter des tests unitaires ;
- proposer une interface graphique ;
- améliorer l'accessibilité des couleurs et des messages.

## 🎓 Contexte

Projet scolaire réalisé à l'**ETML – section informatique**.

## 📄 Licence

Le code de ce projet est distribué sous licence MIT. Consulte le fichier [LICENSE](LICENSE).

---

<div align="center">
Développé par <a href="https://github.com/Pt74bsx">Romain-Augusto</a>.
</div>
