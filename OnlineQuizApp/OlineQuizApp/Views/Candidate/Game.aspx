<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate/CandidateMaster.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="OlineQuizApp.Views.Candidate.Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .cell {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 100px;
            height: 100px;
            border: 5px solid black;
            font-size: 2em;
            font-weight: bold;
            cursor:pointer;
            border-radius: 30px;

        }

        .cell.x {
            color: red;
        }

        .cell.o {
            color: blue;
        }

        .game-board {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 5px;
            width: 315px;
            margin: auto;
            border-radius: 30px;
            box-shadow: 5px 5px 15px 15px rgba(0, 0, 0, 0.3);
        }

        .hidden {
            display: none;
        }
        #reset{
            position:relative;
            left:220px;
        }
    </style>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div id="tic-tac-toe-game" class="game-container">
                    <h2 class="text-center">Tic-Tac-Toe</h2>
                    <div class="game-board">
                        <div class="cell" data-id="0"></div>
                        <div class="cell" data-id="1"></div>
                        <div class="cell" data-id="2"></div>
                        <div class="cell" data-id="3"></div>
                        <div class="cell" data-id="4"></div>
                        <div class="cell" data-id="5"></div>
                        <div class="cell" data-id="6"></div>
                        <div class="cell" data-id="7"></div>
                        <div class="cell" data-id="8"></div>
                    </div>
                    <button class="btn btn-success mt-3" id="reset" onclick="resetGame()">Reset Game</button>
                    <div id="winMessage" class="alert alert-success mt-3 hidden" role="alert">
                        Player <span id="winner"></span> wins!
                    </div>
                    <div id="drawMessage" class="alert alert-warning mt-3 hidden" role="alert">
                        It's a draw!
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        let currentPlayer = 'x';
        let board = Array(9).fill(null);

        document.addEventListener('DOMContentLoaded', (event) => {
            document.querySelectorAll('.cell').forEach(cell => {
                cell.addEventListener('click', makeMove);
            });
        });

        function makeMove(event) {
            const cell = event.currentTarget;
            const cellIndex = cell.dataset.id;

            if (board[cellIndex] || checkWin()) return;

            board[cellIndex] = currentPlayer;
            cell.classList.add(currentPlayer);
            cell.textContent = currentPlayer.toUpperCase();

            if (checkWin()) {
                document.getElementById('winner').textContent = currentPlayer.toUpperCase();
                document.getElementById('winMessage').classList.remove('hidden');
            } else if (board.every(cell => cell)) {
                document.getElementById('drawMessage').classList.remove('hidden');
            }

            currentPlayer = currentPlayer === 'x' ? 'o' : 'x';
        }

        function checkWin() {
            const winPatterns = [
                [0, 1, 2],
                [3, 4, 5],
                [6, 7, 8],
                [0, 3, 6],
                [1, 4, 7],
                [2, 5, 8],
                [0, 4, 8],
                [2, 4, 6]
            ];

            return winPatterns.some(pattern => {
                const [a, b, c] = pattern;
                return board[a] && board[a] === board[b] && board[a] === board[c];
            });
        }

        function resetGame() {
            board.fill(null);
            document.querySelectorAll('.cell').forEach(cell => {
                cell.classList.remove('x', 'o');
                cell.textContent = '';
            });
            document.getElementById('winMessage').classList.add('hidden');
            document.getElementById('drawMessage').classList.add('hidden');
            currentPlayer = 'x';
        }
    </script>
</asp:Content>
