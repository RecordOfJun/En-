package controller.commands;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

import controller.commandExcution;
import model.DirectoryData;
import view.CommandResult;

public class DIR implements commandExcution {
	CommandResult commandResult;
	DirectoryData directoryData;
	File path;
	public DIR(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		dirBranch(command);
		a();
	}
	private void synchronizeFile() {
		path=new File(directoryData.getDirectory());
	}
	private void dirBranch(String extraLine) {
		String extraCommand=extraLine.trim();
		if(extraCommand.contains(":"))//절대경로 이동
			moveToAbsolutePath(extraCommand);
		else//상대경로 이동
			moveToRelativePath(extraCommand);
	}
	private void moveToAbsolutePath(String filePath) {
		path=new File(filePath);
			
	}
	private void moveToRelativePath(String filePath) {
		path=new File(path.getPath()+"\\"+filePath);
	}
	private void a() {
		File[] files=path.listFiles();
		for(int count=0;count<files.length;count++) {
			if(!files[count].isHidden()) {
				Date lastModified=new Date(files[count].lastModified());
				if(files[count].isDirectory()) {
					commandResult.showDirectoryData(lastModified,"<DIR>",files[count].getName());
				}
				else if(files[count].isFile()) {
					long fileByte=files[count].length();
					commandResult.showFileData(lastModified, fileByte, files[count].getName());
				}
		
			}
		}
	}
}
