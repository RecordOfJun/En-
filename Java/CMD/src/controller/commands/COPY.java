package controller.commands;



import java.io.File;
import java.nio.file.Files;

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
				
				break;
		}

	}
	private void transferEqual(String filePath) {
		if(filePath.equals(""))
			commandResult.announceWrongCommand();
		else {
			movePath(filePath);
			path=new File(getPath(path));
			if(path.exists())
				commandResult.announceCanNotCopySameFile();
			else
				commandResult.announceFileFindFailed();
		}
	}
	private void two(String leftPath,String rightPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			if(leftPath.equals(rightPath))
				commandResult.announceCanNotCopySameFile();
			else {
				tryCopy(rightPath);
			}
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	private void tryCopy(String rightPath) {
		File leftFile=new File(getPath(path));
		synchronizeFile();
		movePath(rightPath);
		File rightFile=new File(getPath(path));
		if(rightFile.exists()) {//물어보기
			commandResult.askCopy(rightPath);
		}
		else {
			try {
				Files.copy(leftFile.toPath(), rightFile.toPath());
			}
			catch(Exception e){
				commandResult.announcePathFindFailed();
				commandResult.announceCopyComplete(0);
			}
		}
	}
}