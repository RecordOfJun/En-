package controller.commands;

import java.io.File;

import model.DirectoryData;
import view.CommandResult;

public class Command {
	protected CommandResult commandResult;
	protected DirectoryData directoryData;
	protected File path;
	public Command(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	protected void synchronizeFile() {
		path=new File(directoryData.getDirectory());
	}
	protected void movePath(String extraLine) {
		String extraCommand=extraLine.trim();
		if(extraCommand.startsWith("\\")){
			extraCommand="c:"+extraCommand;
		}
		if(extraCommand.contains(":"))//절대경로 이동
			moveToAbsolutePath(extraCommand);
		else//상대경로 이동
			moveToRelativePath(extraCommand);
	}
	protected void moveToAbsolutePath(String filePath) {
		path=new File(filePath);
		path=new File(getPath(path));
			
	}
	protected void moveToRelativePath(String filePath) {
		path=new File(path.getPath()+"\\"+filePath);
		path=new File(getPath(path));
	}
	protected String getPath(File file) {
		try {
			String canonicalPath=file.getCanonicalPath();
			return canonicalPath;
		}
		catch(Exception e) {
			return "";
		}
	}
}
