package model;

public class State {
	private int lastType;
	private boolean isError;
	private boolean isLog;
	public State() {
		isError=false;
		isLog=false;
	}
	public int getLastType() {
		return lastType;
	}
	public void setLastType(int lastType) {
		this.lastType=lastType;
	}
	public void setIsError(boolean bool) {
		isError=bool;
	}
	public boolean getIsError() {
		return isError;
	}
	public void setIsLog(boolean bool) {
		isLog=bool;
	}
	public boolean getIsLog() {
		return isLog;
	}
}
