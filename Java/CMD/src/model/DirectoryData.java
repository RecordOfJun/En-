package model;

public class DirectoryData {
	private String CurrentDirecorty;//현재 cmd가 속해있는 파일경로 저장
	public void setDirectory(String path) {
		this.CurrentDirecorty=path;
	}
	public String getDirectory() {
		return CurrentDirecorty;
	}
}
