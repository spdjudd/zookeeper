// File generated by hadoop record compiler. Do not edit.
/**
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using Org.Apache.Jute;

namespace Org.Apache.Zookeeper.Server.Persistence
{
public class FileHeader : IRecord, IComparable 
{
  public FileHeader() {
  }
  public FileHeader(
  int magic
,
  int version
,
  long dbid
) {
Magic=magic;
Version=version;
Dbid=dbid;
  }
  public int Magic { get; set; } 
  public int Version { get; set; } 
  public long Dbid { get; set; } 
  public void Serialize(IOutputArchive a_, String tag) {
    a_.StartRecord(this,tag);
    a_.WriteInt(Magic,"magic");
    a_.WriteInt(Version,"version");
    a_.WriteLong(Dbid,"dbid");
    a_.EndRecord(this,tag);
  }
  public void Deserialize(IInputArchive a_, String tag) {
    a_.StartRecord(tag);
    Magic=a_.ReadInt("magic");
    Version=a_.ReadInt("version");
    Dbid=a_.ReadLong("dbid");
    a_.EndRecord(tag);
}
  public override String ToString() {
    try {
      System.IO.MemoryStream ms = new System.IO.MemoryStream();
      System.IO.BinaryWriter writer =
        new System.IO.BinaryWriter(ms);
      BinaryOutputArchive a_ = 
        new BinaryOutputArchive(writer);
      a_.StartRecord(this,"");
    a_.WriteInt(Magic,"magic");
    a_.WriteInt(Version,"version");
    a_.WriteLong(Dbid,"dbid");
      a_.EndRecord(this,"");
      ms.Position = 0;
      return System.Text.Encoding.UTF8.GetString(ms.ToArray());
    } catch (Exception ex) {
      Console.WriteLine(ex.StackTrace);
    }
    return "ERROR";
  }
  public void Write(System.IO.BinaryWriter writer) {
    BinaryOutputArchive archive = new BinaryOutputArchive(writer);
    Serialize(archive, "");
  }
  public void ReadFields(System.IO.BinaryReader reader) {
    BinaryInputArchive archive = new BinaryInputArchive(reader);
    Deserialize(archive, "");
  }
  public int CompareTo (object peer_) {
    if (!(peer_ is FileHeader)) {
      throw new InvalidOperationException("Comparing different types of records.");
    }
    FileHeader peer = (FileHeader) peer_;
    int ret = 0;
    ret = (Magic == peer.Magic)? 0 :((Magic<peer.Magic)?-1:1);
    if (ret != 0) return ret;
    ret = (Version == peer.Version)? 0 :((Version<peer.Version)?-1:1);
    if (ret != 0) return ret;
    ret = (Dbid == peer.Dbid)? 0 :((Dbid<peer.Dbid)?-1:1);
    if (ret != 0) return ret;
     return ret;
  }
  public override bool Equals(object peer_) {
    if (!(peer_ is FileHeader)) {
      return false;
    }
    if (peer_ == this) {
      return true;
    }
    bool ret = false;
    FileHeader peer = (FileHeader)peer_;
    ret = (Magic==peer.Magic);
    if (!ret) return ret;
    ret = (Version==peer.Version);
    if (!ret) return ret;
    ret = (Dbid==peer.Dbid);
    if (!ret) return ret;
     return ret;
  }
  public override int GetHashCode() {
    int result = 17;
    int ret;
    ret = (int)Magic;
    result = 37*result + ret;
    ret = (int)Version;
    result = 37*result + ret;
    ret = (int)Dbid;
    result = 37*result + ret;
    return result;
  }
  public static string Signature() {
    return "LFileHeader(iil)";
  }
}
}