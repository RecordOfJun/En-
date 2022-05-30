package controller.commands.tranformation;

import java.io.File;
import java.util.Scanner;

import controller.commandExcution;
import controller.commands.Command;
import model.DirectoryData;
import view.CommandResult;

public class TransForm extends Command implements commandExcution {
	public TransForm(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
	}
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		setBranchByCommandLength(command);
	}
	protected void setBranchByCommandLength(String command) {
		String[] filePaths=command.trim().split("[\\s]+");
		switch(filePaths.length) {
			case 1:
				transferEqual(filePaths[0]);
				break;
			case 2:
				two(filePaths[0], filePaths[1]);
				break;
			default:
				three(filePaths[0]);
				break;
		}

	}
	protected void transferEqual(String filePath) {
		if(filePath.equals(""))
			commandResult.announceWrongCommand();
		else {
			two(filePath,"");
		}
	}
	protected void two(String leftPath,String rightPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			transferFile(rightPath);
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	protected void three(String leftPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			commandResult.announceWrongCommand();
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	protected int askCover(String rightFileName) {
		Scanner userInput=new Scanner(System.in);
		boolean isAnswered=false;
		int answerResult=0;
		while(!isAnswered) {
			commandResult.askCover(rightFileName);
			String answer=userInput.nextLine();
			switch(answer.toLowerCase().charAt(0)) {
				case 'y':
					isAnswered=true;
					answerResult=1;
					break;
				case 'n':
					isAnswered=true;
					answerResult=2;
					break;
				case 'a':
					isAnswered=true;
					answerResult=3;
					break;
				default:
					break;
			}
		}
		return answerResult;
	}
	protected void transferFile(String rightPath) {
		
	}
	protected void announceMoveComplete(File leftFile,int count) {
		if(leftFile.isDirectory())
			commandResult.announceDirectoryMoveComplete(count);
		else
			commandResult.announceFileMoveComplete(count);
	}
}
