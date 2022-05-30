package controller.commands;



import java.io.File;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;

import controller.commandExcution;
import model.DirectoryData;
import view.CommandResult;

public class COPY extends Command implements commandExcution {

	public COPY(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
	}

	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		setBranchByCommandLength(command);
	}
	private void setBranchByCommandLength(String command) {
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
	private void transferEqual(String filePath) {
		if(filePath.equals(""))
			commandResult.announceWrongCommand();
		else {
			two(filePath,"");
		}
	}
	private void two(String leftPath,String rightPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			copyFile(rightPath);
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	private void three(String leftPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			commandResult.announceWrongCommand();
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	private void copyFile(String rightPath) {
		File leftFile=new File(getPath(path));
		synchronizeFile();
		movePath(rightPath);
		File rightFile=new File(getPath(path));
		if(leftFile.isDirectory()) {
			directoryCopy(leftFile,rightFile);
		}
		else if(leftFile.isFile()) {
			int result=fileCopy(leftFile, rightFile);
			if(result==1||result==3)
				commandResult.announceCopyComplete(1);
			else
				commandResult.announceCopyComplete(0);
		}
		
	}
	private void directoryCopy(File leftFile,File rightFile) {
		File[] childFiles=leftFile.listFiles();
		int completeCount=0;
		boolean isAll=false;
		for(int count=0;count<childFiles.length;count++) {
			if(childFiles[count].isFile()) {
				System.out.println(leftFile.getName()+"\\"+childFiles[count].getName());
				if(!isAll) {
					int result=fileCopy(childFiles[count], rightFile);
					if(result==1)
						completeCount++;
					else if(result==3) {
						completeCount++;
						isAll=true;
					}
					else if(result==0) {
						commandResult.announceCopyComplete(0);
						return;
					}
				}
				else {
					File temporaryFile=rightFile.getAbsoluteFile();
					if(temporaryFile.isDirectory())
						temporaryFile=new File(temporaryFile.getPath()+"\\"+childFiles[count].getName());
					tryCopy(childFiles[count], temporaryFile);
					completeCount++;
				}
			}
		}
		commandResult.announceCopyComplete(completeCount);
	}
	private int fileCopy(File leftFile,File rightFile) {
		if(rightFile.isDirectory())
			rightFile=new File(rightFile.getPath()+"\\"+leftFile.getName());
		if(getPath(leftFile).equals(getPath(rightFile))) {
			commandResult.announceCanNotCopySameFile();
			return 0;//오류
		}
		else if(rightFile.exists()) {//물어보기
			switch(askCover(rightFile.getName())) {
				case 1:
					tryCopy(leftFile, rightFile);
					return 1;
				case 2:
					return 2;
				case 3:
					tryCopy(leftFile, rightFile);
					return 3;
			}
		}
		else 
			tryCopy(leftFile, rightFile);
		return 1;
	}
	private int askCover(String rightFileName) {
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
	private void tryCopy(File leftFile,File rightFile) {
		try {
			Files.copy(leftFile.toPath(), rightFile.toPath(),StandardCopyOption.REPLACE_EXISTING);
		}
		catch(Exception e){
			commandResult.announcePathFindFailed();
			commandResult.announceCopyComplete(0);
		}
	}
}