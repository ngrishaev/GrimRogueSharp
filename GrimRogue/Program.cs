using GrimRogue.CharList;
using GrimRogue.Combat;

namespace GrimRogue
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var goblin = new Monster("Goblin", hp: 2, ac: 6, atk: 6, spd: 2);
            var rottenCorpse = new Monster("RottenCorpse", hp: 4, ac: 7, atk: 7, spd: 2);
            var character = new CharList.Character("Hero", strength: 10, dexterity: 10, constitution: 10, intelligence: 10);
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Fight a Goblin");
                Console.WriteLine("2. Exit");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    RunFight(character, goblin);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private static void RunFight(Character character, Monster goblin)
        {
            FightStatus fightStatus = FightStatus.InProgress;
            while (fightStatus == FightStatus.InProgress)
            {
                Console.Clear();
                fightStatus = ProcessUserTurn(character, goblin);
                if (fightStatus == FightStatus.InProgress)
                {
                    fightStatus = ProcessMonsterTurn(character, goblin);
                }
            }
            
            ShowFightResult(fightStatus);
        }

        private static FightStatus ProcessUserTurn(Character character, Monster monster)
        {
            ShowTurnIntro(character);
            var input = Console.ReadLine();
            {
                switch (input)
                {
                    case "1":
                    {
                        Console.WriteLine($"You are attacking the {monster.Name}!");
                        var atkService = new CombatService();
                        var result = atkService.AttackMonster(character, monster);
                        switch (result)
                        {
                            case HitMonster hit:
                                Console.WriteLine($"Rolled {hit.RollToHit} vs {monster.AC} ({monster.Name}'s AC). Success!");
                                Console.WriteLine($"You hit the {hit.Defender} for {hit.Damage} damage! Monster left with {monster.HP} HP.");
                                monster.Hit(hit.Damage);
                                if (monster.HP <= 0)
                                {
                                    return FightStatus.PlayerWon;
                                }
                                break;
                            case MissMonster miss:
                                Console.WriteLine($"You missed! Rolled {miss.RollToHit} vs {monster.AC} ({monster.Name}'s AC).");
                                break;
                        }

                        break;
                    }
                    case "2":
                        Console.WriteLine("You are trying to run away!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return FightStatus.Fled;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return FightStatus.InProgress;
        }

        private static FightStatus ProcessMonsterTurn(Character character, Monster goblin)
        {
            Console.WriteLine($"{goblin.Name} attacks you! Defend!");
            var combatService = new CombatService();
            var result = combatService.DefendMonster(character, goblin);
            switch (result)
            {
                case DeflectMonster deflect:
                    Console.WriteLine($"You rolled {deflect.RollToDefend} vs {goblin.ATK} ({goblin.Name}'s ATK). Success!");
                    Console.WriteLine("You deflected the attack!");
                    break;
                case HitByMonster hitBy:
                    Console.WriteLine($"You rolled {hitBy.RollToDefend} vs {goblin.ATK} ({goblin.Name}'s ATK). Fail!");
                    character.Hit(hitBy.Damage);
                    Console.WriteLine($"{goblin.Name} hits you for {hitBy.Damage} damage! You have {character.CurrentHp} HP left.");
                    break;
            }
                        
            if (character.CurrentHp <= 0)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return FightStatus.PlayerLost;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return FightStatus.InProgress;
        }

        private static void ShowTurnIntro(Character character)
        {
            Console.WriteLine("Its your turn! What would you like to do?");
            Console.WriteLine("1. Attack Goblin");
            Console.WriteLine("2. Run!");
            Console.WriteLine("===");
            Console.WriteLine($"You have {character.CurrentHp} HP left.");
        }

        private static void ShowFightResult(FightStatus fightStatus)
        {
            if (fightStatus == FightStatus.PlayerLost)
            {
                Console.WriteLine("You have been defeated! Game Over.");
            }
            else if (fightStatus == FightStatus.PlayerWon)
            {
                Console.WriteLine("You have defeated the goblin! Victory!");
            }
            else if (fightStatus == FightStatus.Fled)
            {
                Console.WriteLine("You successfully fled from the battle!");
            }
        }
    }

    public enum FightStatus
    {
        InProgress,
        PlayerWon,
        PlayerLost,
        Fled
    }
}