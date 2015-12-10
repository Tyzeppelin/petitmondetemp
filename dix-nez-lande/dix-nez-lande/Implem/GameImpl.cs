using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public class GameImpl : Game
    {
        private Map _map;
        public Map map
        {
            get { return _map; }
            set { _map = value; }
        }

        private List<Player> _players;
        public List<Player> players
        {
            get { return _players; }
            set { _players = value; }
        }

        private int _nbTurn;
        public int nbTurn
        {
            get { return _nbTurn; }
            set { _nbTurn = value; }
        }

        private Player _current;
         public Player current
        {
            get { return _current; }
            set { _current = value; }
        }

        private History _saveStates;
        public History saveStates
        {
            get { return _saveStates; }
            set { _saveStates = value; }
        }

        public GameImpl() { }


        public int getPoints(Unit u)
        {
            return map.tiles[u.pos.x*map.size + u.pos.y].getPoints(u.race);
        }

        public void start()
        {
            saveStates.set(GameStateFactory.getStateFactory().createGameState());
            beginTurn();
        }

        public void beginTurn()
        {
            Console.WriteLine("Le joueur " + current.name + " commence son tour");
        }

        public void endTurn()
        {
            foreach (Unit unit in current.units)
            {
                current.points += getPoints(unit);
            }
            Console.WriteLine("Le joueur " + current.name + " a fini de jouer son tour");
            if (nbTurn == 0)
            {
                endGame();
            }
            else
            {
                switchPlayer();
            }
            nbTurn--;
            // Pour l'history
            if (nbTurn%2 == 0)
            {
                GameState gs = saveStates.stateToSave;
                gs.player1 = current;
                gs.nbTurn = nbTurn;
                saveStates.set(gs);
                saveStates.save();
                saveStates.set(GameStateFactory.getStateFactory().createGameState());
            }
            else
            {
                GameState gs = saveStates.stateToSave;
                gs.player2 = current;
                saveStates.set(gs);
            }
        }

        public void switchPlayer()
        {
            if (current == players[0])
            {
                current = players[1];
            }
            else
            {
                current = players[0];
            }
            beginTurn();
        }

        public void endGame()
        {
            Console.WriteLine("Le joueur " + whoWin() + " a gagné !");
        }

        public void rageQuit()
        {
            Console.WriteLine("Le joueur " + current.name + " abandonne lâchement");
            current.points = -1;
            endGame();
        }

        public Player whoWin()
        {
            return players[0].points > players[1].points? players[0]:players[1];
        }

        public void undo()
        {
            GameState gs = saveStates.pop();
            nbTurn = gs.nbTurn;
            if (gs.player1.name == players[0].name) {
                players[0] = gs.player1;
                players[1] = gs.player2;
            }else
            {
                players[0] = gs.player2;
                players[1] = gs.player1;
            }
        }

        public List<Position> suggest()
        {
            List<Position> agg = new List<Position>();
            foreach (Unit u in current.units)
            {
                if (map.canMove(u.pos.x + 1, u.pos.y, u.race)) agg.Add(PositionImpl.getPosition(u.pos.x+1,u.pos.y));
                else if (map.canMove(u.pos.x - 1, u.pos.y, u.race)) agg.Add(PositionImpl.getPosition(u.pos.x - 1, u.pos.y));
                else if( map.canMove(u.pos.x, u.pos.y +1, u.race)) agg.Add(PositionImpl.getPosition(u.pos.x , u.pos.y+1));
                else if( map.canMove(u.pos.x, u.pos.y -1, u.race)) agg.Add(PositionImpl.getPosition(u.pos.x, u.pos.y-1));
            }
            List<Position> res = new List<Position>();
            foreach (Position p in agg)
            {
                if (!res.Contains(p)) {
                    res.Add(p);
                }
            }
            return res;
        }
    }
}
