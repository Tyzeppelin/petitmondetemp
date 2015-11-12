---
title: Projet Dix-nex-lande
author: Francois Boschet \newline Aurélien Fontaine
header-includes:
    - \usepackage[frenchb]{babel}
    - \usepackage{graphicx}
    - \usepackage{float}
    - \usepackage[top=2.5cm, bottom=2.5cm, left=2.5cm, right=2.5cm]{geometry}
    - \usepackage{fancyhdr}
    - \pagestyle{fancy}
    - \fancyhead[CO,CE]{}
    - \fancyfoot[CO,CE]{}
    - \fancyfoot[LE,RO]{\thepage}
abstract: Réalisation d’un jeu vidéo inspiré de Smallworld et de Civilisation. Le projet est réalisé intégralement avec Visual Studio\texttrademark et contiendra donc beaucoup d’humour et de sarcasmes.
---

# Présentation de dix-nex-lande

Le but de ce projet est la réalisation, en C#/C++ avec Visual Studio\texttrademark, d’un jeu sous la forme d’un jeu de plateau
qui s’inspire des plus grands, à savoir Smallworld et Civilisation. La partie graphique du jeu vidéo sera réalisé en C# grâce à la
superbe bibliothèque WPF, le moteur du jeu quand à lui sera réalisé en C# pour les structures de données et en C++ managé pour les algorithmes.

Le but du jeu est, pour chaque joueur, d’amasser plus de points que l’adversaire. Les points sont comptés en fonction du nombre de cases qu’il contrôle.
Pour contrôler une case, le joueur doit avoir au minimum une de ses unité sur la case. Il y a un seul type d’unité pour chacune des trois races
jouables par le joueur que sont les humains, les elfes et les orques. Pour capturer les cases ennemies, un joueur doit au préalable détruire toutes les
unités présentes dessus. Les combats se font entre deux cases adjacentes (Nord, Sud, Est Ouest), ou, dans le cas des orcs, à deux cases de distance
si la case sur laquelle est situé l’orc attaquant est du type montagne.
Les combats se jouent entre deux unités ennemis, l’attaquant inflige un nombre de dégâts au défenseur qui est fonction de ses points d’attaque
et des points de défense du défenseur. Lorsque les points de vie d’une unité tombent à zéro elle est détruite.
Le jeu se déroule au \og tour par tour \fg{}, c’est à dire que les joueurs jouent chacun leur tours.


Il doit aussi y avoir une manière de retourner un tour dans le passé (hommage à Code Lyoko) au moyen d’un code de triche.

# Modélisation du jeu

Nous avons commencé par découper notre API de manière intuitive. Nous avons donc séparé les différents éléments clés comme le jeu, la carte, le joueur, etc.
Une fois ces éléments mis en place, nous avons remarqué que les tuiles étaient toujours les 4 mêmes : forêt, mer, montagne et plaine.
Une fabrique-poids-mouche s'est donc imposée afin de réduire le nombre d’instanciation de nos tuiles. e jeu peut être joué selon différents "modes".
En fonction du mode de jeu choisi, la carte générée doit être plus ou moins grande. Une stratégie est la solution permettant de changer à la volée
des objets complexes, donc nous l'avons utilisée pour créer la carte selon le mode de jeu.

Nous nous sommes heurtés à un problème : comment les unités peuvent elles savoir où elles sont et comment les bouger / faire attaquer d'autres unités ?
Pour y remédier, nous avons procédé le ma manière suivante :

- Chaque unité a une position ;
- Dans la carte, une table de hachage est présente avec les positions en clef et une liste d'unités présentes sur cette position ;
- Lors de l'attaque d'une unité, celle-ci attaque une position ;
- La carte décide quelle unité va être attaquée et la retourne à l'unité attaquante ;
- Lors d'un déplacement, il y a une double modification à faire à la fois dans l'unité et dans la carte.

Nous sommes encore en train de travailler pour améliorer cette gestion, car la duplication de position peut être source d'erreurs.

\begin{figure}[H]
    \centering
    \includegraphics[width=1\textwidth]{model.png}
    \caption{Model}
    \label{fig:model}
\end{figure}

Tout d'abord, afin de créer le jeu en une seule fois, nous avons utilisé un constructeur (builder). Ainsi, toute l'initialisation passe par lui, notamment quand à la sélection des différentes valeurs en fonction du mode de jeu. Dans ce constructeur, de nombreuses fabriques sont appelées, comme une fabrique de joueur ou une fabrique de carte.

\begin{figure}[H]
    \centering
    \includegraphics[width=1\textwidth]{implem.png}
    \caption{implem}
    \label{fig:model}
\end{figure}

# Fonctionnement

Le mécanisme des combats sont assez simplistes et foncitonnent comme suit:

\begin{figure}[H]
    \centering
    \includegraphics[width=0.4\textwidth]{attaque_statechart.png}
    \caption{Mécanisme d’attaque}
    \label{fig:attaque}
\end{figure}

La création de la partie se fait grace au builder, de la manièreexpliqué dans le diagramme d’activité sur le [gitlab](https://gitlab.insa-rennes.fr/aurelien-fontaine/dix-nez-lande/blob/master/report/1_models/Diagramme_activites.pdf).
Le diagramme de séquence pour le builder quand à lui est disponible aussi sur le [gitlab](https://gitlab.insa-rennes.fr/aurelien-fontaine/dix-nez-lande/blob/master/report/1_models/DiagrammeDeSequence.pdf).

# Reste à faire

Maintenant que nous avons terminé la partie de modélisation, nous alons nous attaquer à la partie graphique! Il va falloir tout d’abord créer
les algorithmes de déroulement du jeu en C++ managé, notamment les algorithmes de combat.

Il faudra aussi réaliser toute la partie graphique grace au framework WPF.
