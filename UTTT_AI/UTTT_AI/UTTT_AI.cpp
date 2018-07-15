#include "Include.h"

struct Board
{
    Board()
    {
        row = 0;
        col = 0;
        value = Empty;
        empty_cells = BOARD_SIZE;
        changed_at = _NULL;
        level = 0;
    }

    bool isFull()
    {
        return empty_cells == 0;
    }

    bool isEmpty()
    {
        return empty_cells == BOARD_SIZE;
    }

    int row, col, level, empty_cells, changed_at;
    Player value;
    Board* subboards[BOARD_HEIGHT][BOARD_WIDTH];
};

struct Move
{
    Move()
    {
        row = column = _NULL;
    }

    Move(int row, int col) : row(row), column(col) {}

    int row, column;

    string output()
    {
        string moves;
        int _row, _col;
        _row = row / BOARD_HEIGHT;
        _col = column / BOARD_WIDTH;
        moves += to_string(_row) + to_string(_col);

        _row = row  % BOARD_HEIGHT;
        _col = column %	BOARD_WIDTH;
        moves += to_string(_row) + to_string(_col);
        if (visualization_enabled)
        {
            moves += get_score_string();
        }
        return moves;
    }

    string get_score_string() const
    {
        string result;
        for (auto move : scores)
        {
            result += "|" + to_string((move.first).row) + ";" +
                to_string((move.first).column) + ";" +
                to_string(move.second);
        }
        return result;
    }

    bool operator!=(Move& move)
    {
        return !(move == *this);
    }
    bool operator==(Move move)
    {
        return row == move.row && column == move.column;
    }
    bool operator<(const Move move) const
    {
        if (row == move.row)
        {
            return column < move.column;
        }
        return row < move.row;
    }
};

struct State
{
    State()
    {
        moves.clear();
        move_num = 0;
        current_player = Cross;
        board = Board();
        initialize(board);
    }

    void initialize(Board& board, int level = 1)
    {
        for (int row = 0; row<BOARD_HEIGHT; ++row)
        {
            for (int col = 0; col<BOARD_WIDTH; ++col)
            {
                Board& new_board = *(new Board());
                new_board.row = board.row * BOARD_HEIGHT + row;
                new_board.col = board.col * BOARD_WIDTH + col;
                new_board.level = level;

                board.subboards[row][col] = &new_board;
                if (level < LEVELS)
                {
                    initialize(new_board, level + 1);
                }
            }
        }
    }

    Board get_next_board()
    {
        int row = moves.back().row  % BOARD_HEIGHT;
        int col = moves.back().column % BOARD_WIDTH;
        return *board.subboards[row][col];
    }

    Player current_player;
    Board board;
    Moves moves;
    int move_num;
};

struct Grid
{
    Grid()
    {
        area.assign(GRID_HEIGHT, vector<Player>(GRID_WIDTH, Empty));
    }

    Grid(string grid_string)
    {
        area.assign(GRID_HEIGHT, vector<Player>(GRID_WIDTH, Empty));
        string row_str;
        for (int row = 0; row<GRID_HEIGHT; ++row)
        {
            row_str = grid_string.substr(9 * row, 9);
            for (int col = 0; col<GRID_WIDTH; ++col)
            {
                area[row][col] = symbol_to_value(row_str[col]);
            }
        }
    }

    vector<Player>& operator[](int index)
    {
        return area[index];
    }

    Move get_empty_move(Moves &moves)
    {
        for (int row = 0; row < GRID_HEIGHT; ++row)
        {
            for (int col = 0; col < GRID_WIDTH; ++col)
            {
                if (area[row][col] != Empty)
                {
                    Move move(row, col);
                    if (find(moves.begin(), moves.end(), move) == moves.end())
                    {
                        return move;
                    }
                }
            }
        }
        return Move();
    }

    vector<vector<Player>> area;
};

void add_cell(Moves& line, int row, int col)
{
    Move cell(row, col);
    line.push_back(cell);
}

vector<Moves>& get_lines(Board& board)
{
    static vector<Moves> lines;

    if (lines.size() == 0)
    {
        Moves line;

        for (int row = 0; row<BOARD_HEIGHT; ++row)
        {
            line.clear();
            for (int col = 0; col<BOARD_WIDTH; ++col)
            {
                add_cell(line, row, col);
            }
            lines.push_back(line);
        }

        for (int col = 0; col<BOARD_WIDTH; ++col)
        {
            line.clear();
            for (int row = 0; row<BOARD_WIDTH; ++row)
            {
                add_cell(line, row, col);
            }
            lines.push_back(line);
        }

        line.clear();
        for (int row = 0; row<BOARD_HEIGHT; ++row)
        {
            add_cell(line, row, row);
        }
        lines.push_back(line);

        line.clear();
        for (int row = 0; row<BOARD_HEIGHT; ++row)
        {
            add_cell(line, row, BOARD_HEIGHT - 1 - row);
        }
        lines.push_back(line);
    }
    return lines;
}


bool is_won(Board& board, Player player)
{
    vector<Moves>& lines = get_lines(board);
    int len = lines.size();
    for (int i = 0; i<len; ++i)
    {
        Moves& line = lines[i];
        bool is_complete = true;
        int len = line.size();
        for (int i = 0; i<len; ++i)
        {
            Move& cell = line[i];
            Player cell_value = board.subboards[cell.row][cell.column]->value;
            if (cell_value != player)
            {
                is_complete = false;
            }
        }
        if (is_complete)
        {
            return true;
        }
    }
    return false;
}


Player get_board_state(Board& board)
{
    if (board.value != Empty) return board.value;
    else if (is_won(board, Cross)) return Cross;
    else if (is_won(board, Nough)) return Nough;
    else if (board.isFull()) return Draw;
    else return Empty;
}


Board& get_subboard(Board& board, Move move)
{
    int row, col;
    if (board.level < LEVELS - 1)
    {
        row = move.row / BOARD_HEIGHT;
        col = move.column / BOARD_WIDTH;
    }
    else
    {
        row = move.row  % BOARD_HEIGHT;
        col = move.column %	BOARD_WIDTH;
    }
    return *board.subboards[row][col];
}

void make_move(State& state, Board &board, Move move, Player player)
{
    if (board.level < LEVELS)
    {
        Board& subboard = get_subboard(board, move);
        make_move(state, subboard, move, player);

        if (subboard.changed_at == state.move_num)
        {
            --board.empty_cells;
            Player new_value = get_board_state(board);
            if (board.value != new_value)
            {
                board.value = new_value;
                board.changed_at = state.move_num;
            }
        }

        if (board.level == 0)
        {
            state.moves.push_back(move);
            ++state.move_num;
        }
    }
    else
    {
        board.value = player;
        board.changed_at = state.move_num;
    }
}

void cancel(State& state, Board &board)
{
    if (board.level < LEVELS)
    {
        if (board.changed_at == state.move_num - 1)
        {
            board.value = Empty;
            board.changed_at = -1;
        }
        Board& subboard = get_subboard(board, state.moves.back());
        if (subboard.changed_at == state.move_num - 1)
        {
            ++board.empty_cells;
        }
        cancel(state, subboard);
    }
    else
    {
        board.value = Empty;
        board.changed_at = -1;
        state.moves.pop_back();
        --state.move_num;
    }
}

bool isGameEnded(State& state)
{
    return (state.board.value != Empty);
}

vector<Board>& getActiveBoards(State& state)
{
    vector<Board>* boards = new vector<Board>;

    bool move_anywhere = true;
    if (state.moves.size() > 0)
    {
        Board next_board = state.get_next_board();
        if (next_board.value == Empty)
        {
            move_anywhere = false;
            boards->push_back(next_board);
        }
    }

    if (move_anywhere)
    {
        for (int row = 0; row<BOARD_HEIGHT; ++row)
        {
            for (int col = 0; col<BOARD_WIDTH; ++col)
            {
                Board& brd = *state.board.subboards[row][col];
                if (!brd.isFull()
                    && !is_won(brd, Cross) && !is_won(brd, Nough)
                    )
                {
                    boards->push_back(brd);
                }
            }
        }
    }
    return *boards;
}

Moves& getPossibleMoves(Board& board)
{
    Moves* moves = new Moves;
    for (int row = 0; row<BOARD_HEIGHT; ++row)
    {
        for (int col = 0; col<BOARD_WIDTH; ++col)
        {
            Board& brd = *board.subboards[row][col];
            if (brd.value == Empty)
            {
                Move move;
                move.row = brd.row;
                move.column = brd.col;
                moves->push_back(move);
            }
        }
    }
    return *moves;
}

Moves& get_allowed_moves(State& state)
{
    Moves* moves = new Moves;
    vector<Board>& active_boards = getActiveBoards(state);
    for (vector<Board>::iterator brd = active_boards.begin(); brd != active_boards.end(); ++brd) {
        Moves& board_moves = getPossibleMoves(*brd);
        moves->insert(moves->end(), board_moves.begin(), board_moves.end());
        delete(&board_moves);
    }
    delete(&active_boards);
    return *moves;
}

bool line_is_allowed(Board& board, Moves& line, Player player)
{
    bool is_possible = true;
    for (int i = 0; i<WIN_LINE_LENGTH; ++i)
    {
        Move& cell = line[i];
        Player cell_value = board.subboards[cell.row][cell.column]->value;
        if (cell_value != Empty && cell_value != player)
        {
            is_possible = false;
            break;
        }
    }
    return is_possible;
}

int get_board_score(Board& board, Player player, int full_score);

int get_line_score(Board& board, Moves& line, Player player, int full_score) 
{
    int line_score = 0;
    int len = line.size();
    for (int i = 0; i<len; ++i)
    {
        Move& cell = line[i];
        Board& cell_board = *board.subboards[cell.row][cell.column];
        int cell_score = get_board_score(cell_board, player, full_score / len);
        line_score += cell_score;
    }

    return line_score;
}

int get_board_score(Board& board, Player player, int full_score)
{
    int board_score;

    if (board.value == player)
    {
        board_score = full_score;
    }
    else if (board.value != Empty)
    {
        board_score = 0;
    }
    else if (board.isEmpty() && board.level >= LEVELS - 1)
    {
        board_score = 0;
    }
    else
    {
        vector<Moves>& lines = get_lines(board);

        int best_line_score = 0;

        int length = lines.size();
        for (int i = 0; i<length; ++i)
        {
            Moves& line = lines[i];
            if (line_is_allowed(board, line, player))
            {
                int line_score = get_line_score(board, line, player, full_score);
                best_line_score = max(best_line_score, line_score);
            }

        }

        board_score = best_line_score;
        board_score = board_score * board_score / full_score;
    }

    return board_score;
}

int evaluation_function(State& state, Player player)
{
    const int WIN_SCORE = 1000;
    const int LOOSE_SCORE = -1000;
    const int DRAW_SCORE = 0;
    const int MOVE_SCORE = 10;

    Board& board = state.board;

    int score;
    if (board.value == player)
    {
        score = WIN_SCORE - MOVE_SCORE * state.move_num;
    }
    else if (board.value == nextPlayer(player))
    {
        score = LOOSE_SCORE + MOVE_SCORE * state.move_num;
    }
    else if (board.value == Draw)
    {
        score = DRAW_SCORE;
    }
    else
    {
        if (BOARD_SCORE_ALLOWED)
        {
            int my_score = get_board_score(board, player, WIN_SCORE);
            int enemy_score = get_board_score(board, nextPlayer(player), WIN_SCORE);
            score = my_score - enemy_score;
        }
        else
        {
            score = 0;
        }
    }
    return score;
}

pair<Move, int> minimax(State& state, Player player, int turn, int alpha, int beta)
{
    Moves& moves = get_allowed_moves(state);

    pair<Move, int> best_move;
    best_move.first = Move();
    best_move.second = -10000;

    map<Move, int> copy;

    for (auto move : moves)
    {
        int score;
        make_move(state, state.board, move, player);


        if (isGameEnded(state) || turn == 0)
        {
            score = evaluation_function(state, player);

        }
        else
        {
            pair<Move, int> response = minimax(state, nextPlayer(player), turn - 1, -beta, -alpha);
            score = -response.second;
        }
        cancel(state, state.board);

        if (visualization_enabled)
        {
            copy[move] = score;
        }

        if (score > best_move.second)
        {
            best_move.first = move;
            best_move.second = score;

            alpha = max(alpha, score);
            if (alpha >= beta)
            {
                break;
            }

        }
    }

    if (visualization_enabled)
    {
        scores = copy;
    }

    delete(&moves);

    return best_move;
}

Move get_best_move(State& state, int max_turn = INT_MAX)
{
    positions_done = 0;

    if (visualization_enabled)
    {
        scores.clear();
    }

    pair<Move, int> move = minimax(state, state.current_player, max_turn, -INT_MAX, INT_MAX);

    return move.first;
}

class FileManager
{
    const string SAVE_FILENAME = "Game.ai";

    Moves load_moves(ifstream& save_file)
    {
        Moves moves;
        int moves_num;
        save_file >> moves_num;
        for (int i = 0; i < moves_num; ++i)
        {
            Move move;
            save_file >> move.row >> move.column;
            moves.push_back(move);
        }
        return moves;
    }

    void save_moves(Moves moves, ofstream& save_file)
    {
        save_file << moves.size() << endl;
        for (auto move : moves)
        {
            save_file << move.row << " " << move.column << endl;
        }
    }

    State& new_state(Moves& moves)
    {
        State& state = *(new State());
        for (int i = 0; i<moves.size(); ++i)
        {
            Move move = moves[i];
            make_move(state, state.board, move, state.current_player);
            state.current_player = nextPlayer(state.current_player);
        }
        return state;
    }

public:
    State& load_state()
    {
        Moves prev_moves;
        ifstream save_file(SAVE_FILENAME);
        if (save_file)
        {
            prev_moves = load_moves(save_file);
        }
        save_file.close();
        State& state = new_state(prev_moves);
        return state;
    }

    void save_state(State& state)
    {
        ofstream save_file(SAVE_FILENAME);
        save_file.clear();
        save_moves(state.moves, save_file);
        save_file.close();
    }
};


string AI(string grid_string)
{
    Grid& grid = *(new Grid(grid_string.substr(2)));

    FileManager file_manager;
    State& state = file_manager.load_state();
    Move opponents_move = grid.get_empty_move(state.moves);

    if (opponents_move != Move())
    {
        make_move(state, state.board, opponents_move, state.current_player);
        state.current_player = nextPlayer(state.current_player);
    }

    int depth;
    switch (grid_string[0])
    {
    case '0': depth = 2; break;
    case '1': depth = 3; break;
    case '2': depth = 5; break;
    }
    if (grid_string[1] == '#')
    {
        visualization_enabled = true;
    }
    else
    {
        visualization_enabled = false;
    }

    Move best_move = get_best_move(state, depth);
    make_move(state, state.board, best_move, state.current_player);

    if (!visualization_enabled)
    {
        file_manager.save_state(state);
    }

    return best_move.output();
}

extern "C" __declspec(dllexport) void FromDLL(char* input, char* result)
{
    string answer = AI(input);
    strcpy(result, answer.c_str());
}
