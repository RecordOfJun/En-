package controller.commands;

import java.util.Scanner;
import view.*;
public class HELP {
	CommandResult commandResult;
	public HELP(CommandResult commandResult) {
		this.commandResult=commandResult;
	}
	public void detectLine(String next) {
		//System.out.println(line.toString());
		if(next!="") {
			System.out.println("있음");
		}
		else {
			System.out.println("없음");
		}
	}
	private void helpBranch(Scanner line) {
		String secondKeyword=line.next();
		System.out.println(secondKeyword);
		switch(secondKeyword) {
		case "cd":
			
			break;
		case "dir":
			
			break;
		case "cls":
			
			break;
		case "help":
			
			break;
		case "copy":
			
			break;
		case "move":
			
			break;
		case "exit":
			
			break;
		case " ":
			commandResult.showAllCommand();
			break;
		default:
			break;
		}
	}
}