#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <math.h>
#include <string>
#include <map>

#pragma warning(disable:4996)  

using namespace std;

const int BOARD_HEIGHT = 3;
const int BOARD_WIDTH = 3;
const int BOARD_SIZE = BOARD_HEIGHT * BOARD_WIDTH;

const int LEVELS = 2;
const int WIN_LINE_LENGTH = 3;

const int GRID_HEIGHT = pow(BOARD_HEIGHT, LEVELS);
const int GRID_WIDTH = pow(BOARD_WIDTH, LEVELS);

const int _NULL = -1;

static bool visualization_enabled = false;

enum Player
{
    Empty,
    Cross,
    Nough,
    Draw
};

Player symbol_to_value(char symbol)
{
    switch (symbol)
    {
    case '-': return Empty;
    case 'X': return Cross;
    case 'O': return Nough;
    }
    return Player::Empty;
}

Player nextPlayer(Player player)
{
    switch (player)
    {
    case Cross: return Nough;
    case Nough: return Cross;
    }
    return Empty;
}

struct Move;
typedef vector <Move> Moves;

map<Move, int> scores;

long positions_done;

bool BOARD_SCORE_ALLOWED = true;

