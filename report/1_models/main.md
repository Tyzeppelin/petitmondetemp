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
abstract: Réalisation d’un jeu inspiré de Smallworld et de Civilisation. Le projet est réalisé intégralement avec Visual Studio\texttrademark et contiendra donc beaucoup d’humour et de sarcasmes.
---

# Présentation de dix-nex-lande

Le but de ce projet est la réalisation, en C#/C++ avec Visual Studio\texttrademark, d’un jeu sous la forme d’un jeu de plateau
qui s’inspire des plus grands, à savoir Smallworld et Civilisation.

Le but du jeu est, pour chaque joueur, d’amasser plus de points que l’adversaire. Les points sont comptés en fonction du nombre de cases qu’il controle.
Pour controler une case, le joueur doit avoir au minimum une de ses unité sur la case. Il y a un seul type d’unité pour chacune des trois races
jouables par le joueur que sont les humains, les elfes et les orques. Pour capturer les cases ennemies, un joueur doit au préalable détruire toutes les
unités présentes dessus. Les combats se font entre deux cases adjacentes (Nord, Sud, Est Ouest), ou, dans le cas des orcs, à deux cases de distance
si la case sur laquelle est situé l’orc attaquant est du type montagne.
Les combats se jouent entre deux unités ennemis, l’attaquant inflige un nombre de dégat au defenseur qui est fonction de ses points d’attaque
et des points de défense du défenseur. Lorsque les points de vie d’une unité tombent à zéro elle est détruite.
Le jeu se déroule au \og tour par tour \fg{}, c’est à dre que les joueurs jouent chacun leur tours.

Il doit aussi y avoir une manière de retourner un tour dans le passé (hommage à Code Lyoko) au moyen d’un code de triche.

# Modélisation de l’API

Nous avons commencé par découper notre API de manière intuitive. Nous avons donc séparé les différents éléments clés comme le jeu, la carte, le joueur, etc. Une fois ces éléments mis en place, nous avons remarqué que les tuiles étaient toujours les 4 mêmes : forêt, mer, montagne et plaine. Une fabrique-poids-mouche s'est donc imposée afin de réduire le nombre d’instanciation de nos tuiles. e jeu peut être joué selon différents "modes". En fonction du mode de jeu choisi, la carte générée doit être plus ou moins grande. Une stratégie est la solution permettant de changer à la volée des objets complexes, donc nous l'avons utilisée pour créer la carte selon le mode de jeu.

Nous nous sommes heurtés à un problème : comment les unités peuvent elles savoir où elles sont et comment les bouger / faire attaquer d'autres unités ? Pour y remédier, nous avons procédé le ma manière suivante :

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

# Fonctionnement de l’API

\begin{figure}[H]
    \centering
    \includegraphics[width=1\textwidth]{implem.png}
    \caption{implem}
    \label{fig:model}
\end{figure}

# Implémentation

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet enim erat, varius accumsan velit semper id. Curabitur dapibus lacinia mollis. Phasellus tincidunt commodo metus. Morbi quis sapien accumsan, varius justo nec, interdum ex. Fusce at lectus sem. Donec eu interdum nulla, eget convallis nunc. Aenean iaculis lacus non turpis auctor, a viverra tortor elementum. Integer eu elit lacinia, placerat nisi id, vehicula ante. Ut hendrerit nisl a libero placerat cursus. Proin non massa leo. Phasellus et elit egestas, varius lectus non, pellentesque dui. Curabitur efficitur ornare congue.

Aenean volutpat imperdiet felis sit amet condimentum. Quisque felis nulla, finibus id iaculis ac, congue ut mi. Donec porttitor urna metus, sit amet pellentesque justo congue non. Integer vulputate tristique dictum. Cras tincidunt lectus tincidunt lorem molestie, ut pulvinar arcu vehicula. Ut elementum, urna a tempus viverra, mauris massa gravida ex, ac efficitur mauris ligula non nunc. Praesent sagittis ipsum a sapien blandit elementum. Etiam condimentum, augue quis dictum ullamcorper, nulla magna congue dolor, a cursus turpis metus ut enim. Proin pulvinar justo eu velit ultrices dignissim. Donec nibh ligula, venenatis sit amet est dignissim, tempor vulputate elit. Mauris feugiat fringilla convallis. Aenean vel fermentum eros. Nullam sollicitudin varius massa ut vulputate. Vivamus pellentesque tortor at erat molestie porttitor.

Duis rhoncus pharetra est, vel pharetra dolor pharetra in. Etiam maximus tempus quam non ultrices. Vestibulum vehicula hendrerit purus in ultrices. Sed id dictum ex. Aliquam erat volutpat. Praesent fermentum augue et hendrerit tincidunt. Cras lobortis tellus nec hendrerit viverra. Sed euismod venenatis enim, tincidunt dapibus ante efficitur et. Sed dictum id arcu sit amet tempor. Nullam ultricies tellus non tellus pretium fringilla. Duis semper vel felis id eleifend. Cras id fringilla eros, et malesuada nibh. 

# Reste à faire

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet enim erat, varius accumsan velit semper id. Curabitur dapibus lacinia mollis. Phasellus tincidunt commodo metus. Morbi quis sapien accumsan, varius justo nec, interdum ex. Fusce at lectus sem. Donec eu interdum nulla, eget convallis nunc. Aenean iaculis lacus non turpis auctor, a viverra tortor elementum. Integer eu elit lacinia, placerat nisi id, vehicula ante. Ut hendrerit nisl a libero placerat cursus. Proin non massa leo. Phasellus et elit egestas, varius lectus non, pellentesque dui. Curabitur efficitur ornare congue.

Aenean volutpat imperdiet felis sit amet condimentum. Quisque felis nulla, finibus id iaculis ac, congue ut mi. Donec porttitor urna metus, sit amet pellentesque justo congue non. Integer vulputate tristique dictum. Cras tincidunt lectus tincidunt lorem molestie, ut pulvinar arcu vehicula. Ut elementum, urna a tempus viverra, mauris massa gravida ex, ac efficitur mauris ligula non nunc. Praesent sagittis ipsum a sapien blandit elementum. Etiam condimentum, augue quis dictum ullamcorper, nulla magna congue dolor, a cursus turpis metus ut enim. Proin pulvinar justo eu velit ultrices dignissim. Donec nibh ligula, venenatis sit amet est dignissim, tempor vulputate elit. Mauris feugiat fringilla convallis. Aenean vel fermentum eros. Nullam sollicitudin varius massa ut vulputate. Vivamus pellentesque tortor at erat molestie porttitor.

Duis rhoncus pharetra est, vel pharetra dolor pharetra in. Etiam maximus tempus quam non ultrices. Vestibulum vehicula hendrerit purus in ultrices. Sed id dictum ex. Aliquam erat volutpat. Praesent fermentum augue et hendrerit tincidunt. Cras lobortis tellus nec hendrerit viverra. Sed euismod venenatis enim, tincidunt dapibus ante efficitur et. Sed dictum id arcu sit amet tempor. Nullam ultricies tellus non tellus pretium fringilla. Duis semper vel felis id eleifend. Cras id fringilla eros, et malesuada nibh. 

